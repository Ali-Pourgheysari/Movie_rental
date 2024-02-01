using Microsoft.EntityFrameworkCore;
using Movie_rental.Data;
using Movie_rental.Entities;

namespace Movie_rental.Services
{
    public class ExecuteQuery
    {
        private readonly MovieRentalDbContext dbContext;

        public ExecuteQuery(MovieRentalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<T> GetExecuteQuery<T>(string query) where T : new()
        {
            List<T> entities = new List<T>();
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                dbContext.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        var entity = new T();
                        foreach (var property in entity.GetType().GetProperties())
                        {
                            try
                            {
                                var value = result[property.Name];
                                if (value != DBNull.Value)
                                {
                                    property.SetValue(entity, value);
                                }
                            }
                            catch
                            {
                                continue;
                            }

                        }
                        entities.Add(entity);
                    }
                }
            }
            return entities;
        }

        public void PostExecuteQuery(string query)
        {
            using (var command = dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                dbContext.Database.OpenConnection();
                command.ExecuteNonQuery();
            }
        }
    }
}
