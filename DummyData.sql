------------------------- 6 language
SET IDENTITY_INSERT Languages ON;

Insert into Languages(Id, Name)
Values
(1, 'English'),
(2, 'Italian'),
(3, 'Japanese'),
(4, 'Mandarin'),
(5, 'French'),
(6, 'German');
SET IDENTITY_INSERT Languages OFF;
--------------------- 30 movies
SET IDENTITY_INSERT Films ON;
Insert into Films(Id, Title, Description, ReleaseYear, LanguageId, RentalDuration, RentalRate, Length, Rating)
Values
(1, 'The Adventure Begins', 'A thrilling journey of discovery.', 2005, 3, 7, 3.99, 120, 'PG'),
(2, 'Lost in Time', 'An epic tale of time travel and mystery.', 2012, 1, 10, 2.50, 150, 'PG-13'),
(3, 'Midnight Shadows', 'A suspenseful thriller under the moonlight.', 2019, 4, 5, 4.75, 110, 'R'),
(4, 'Starlight Dreams', 'A romantic fantasy set in a magical world.', 2008, 2, 8, 3.25, 140, 'PG'),
(5, 'Beyond the Horizon', 'Exploring the uncharted territories of space.', 2015, 5, 14, 5.99, 180, 'PG-13'),
(6, 'Whispers in the Dark', 'A gripping mystery with unexpected twists.', 2011, 6, 7, 2.99, 95, 'R'),
(7, 'City of Ghosts', 'Supernatural encounters in a haunted city.', 2003, 1, 12, 4.50, 130, 'PG'),
(8, 'The Silent Witness', 'A courtroom drama with a shocking revelation.', 2018, 4, 8, 3.75, 125, 'PG-13'),
(9, 'Echoes of War', 'A war drama portraying the struggles of soldiers.', 2006, 2, 6, 4.25, 160, 'R'),
(10, 'Crimson Sunset', 'Crime and passion entwined in a tale of deception.', 2017, 3, 9, 5.50, 110, 'R'),
(11, 'Whirlwind Romance', 'Love blossoms in unexpected places.', 2009, 5, 7, 3.99, 115, 'PG'),
(12, 'In the Line of Fire', 'Action-packed thriller with a heroic protagonist.', 2013, 6, 10, 2.25, 140, 'R'),
(13, 'Beneath the Surface', 'Exploring the mysteries hidden beneath the ocean.', 2016, 1, 8, 4.75, 155, 'PG-13'),
(14, 'Behind Closed Doors', 'Intriguing secrets unfold in a suburban neighborhood.', 2004, 3, 6, 3.25, 120, 'R'),
(15, 'Enchanted Forest', 'A magical journey through an enchanted world.', 2010, 2, 12, 5.99, 170, 'PG'),
(16, 'Shadows of the Past', 'A psychological thriller delving into the past.', 2020, 4, 9, 4.50, 110, 'PG-13'),
(17, 'City of Lights', 'A heartwarming story set in the vibrant city of Paris.', 2007, 5, 14, 3.99, 130, 'PG'),
(18, 'The Final Showdown', 'Epic battles in the quest for justice.', 2014, 6, 7, 2.50, 145, 'R'),
(19, 'Secrets Unveiled', 'Unraveling the mysteries that lie beneath the surface.', 2011, 1, 10, 4.25, 125, 'PG-13'),
(20, 'Midsummer Nights Dream', 'A romantic comedy set in a charming town.', 2005, 2, 8, 5.50, 100, 'PG'),
(21, 'In the Shadows', 'A suspenseful journey into the world of espionage.', 2018, 3, 6, 3.75, 135, 'R'),
(22, 'Cursed Legacy', 'A family saga with a dark and mysterious twist.', 2006, 4, 12, 2.99, 160, 'PG-13'),
(23, 'Eternal Sunshine', 'A poignant tale of love and loss.', 2015, 5, 7, 4.50, 110, 'PG'),
(24, 'Frozen in Time', 'A sci-fi adventure in the frozen landscapes of Antarctica.', 2003, 6, 9, 3.25, 150, 'R'),
(25, 'Haunted Mansion', 'Spine-chilling horror in an eerie mansion.', 2019, 1, 14, 5.99, 120, 'R'),
(26, 'Legends of the Samurai', 'A historical epic set in feudal Japan.', 2012, 2, 10, 4.25, 180, 'PG-13'),
(27, 'City of Angels', 'Romance and drama unfold in the bustling city of Los Angeles.', 2008, 3, 8, 3.50, 140, 'PG'),
(28, 'Whispers of the Wind', 'Mystical journey through a magical world.', 2017, 4, 7, 2.99, 115, 'PG-13'),
(29, 'The Labyrinth', 'Navigating through a labyrinth of secrets and challenges.', 2009, 5, 12, 4.75, 155, 'R'),
(30, 'Under the Moonlight', 'A romantic drama set against the backdrop of a moonlit night.', 2013, 6, 8, 4.25, 130, 'PG'),
(31, 'City of Gold', 'Adventure and treasure hunt in the legendary city of El Dorado.', 2016, 1, 10, 5.50, 145, 'PG-13'),
(32, 'The Final Frontier', 'Space exploration and encounters with alien civilizations.', 2004, 2, 7, 3.99, 120, 'PG'),
(33, 'Desert Mirage', 'A thrilling desert adventure with unexpected twists.', 2020, 3, 9, 3.25, 110, 'R'),
(34, 'Forgotten Realms', 'Exploring forgotten realms and ancient civilizations.', 2011, 4, 14, 2.50, 165, 'PG-13'),
(35, 'City of Shadows', 'A noir-style mystery set in the shadowy corners of a city.', 2014, 5, 8, 4.50, 125, 'PG'),
(36, 'Eternal Flame', 'A fiery romance with passion and intensity.', 2007, 6, 6, 2.99, 140, 'R'),
(37, 'Whispers in the Wilderness', 'Mysterious happenings in the heart of the wilderness.', 2010, 1, 10, 4.75, 150, 'PG'),
(38, 'The Enchanted Castle', 'A magical adventure in a castle filled with enchantments.', 2018, 2, 7, 3.75, 120, 'PG-13'),
(39, 'Shadows of Destiny', 'Fate and destiny intertwine in this gripping drama.', 2006, 3, 9, 5.99, 110, 'R'),
(40, 'City of Dreams', 'A tale of ambition and dreams in a bustling metropolis.', 2015, 4, 12, 4.25, 140, 'PG-13'),
(41, 'Lost Kingdom', 'Discovering ancient mysteries in a lost kingdom.', 2008, 5, 8, 3.50, 125, 'PG'),
(42, 'The Silent Observer', 'A psychological thriller with a mysterious observer.', 2012, 6, 7, 2.99, 135, 'R'),
(43, 'Echoes of Eternity', 'Exploring the echoes of time and eternity.', 2017, 1, 14, 4.50, 130, 'PG-13'),
(44, 'Underworld Chronicles', 'Diving into the dark and mysterious underworld.', 2003, 2, 9, 3.25, 155, 'PG'),
(45, 'City of Illusions', 'A mind-bending journey through a city of illusions.', 2019, 3, 6, 5.99, 110, 'R'),
(46, 'Eternal Twilight', 'A vampire romance set in the twilight hours.', 2011, 4, 8, 4.75, 145, 'PG-13'),
(47, 'Mystic River', 'Mystery and suspense unfold along the banks of a mystic river.', 2014, 5, 10, 3.99, 120, 'PG'),
(48, 'City of Masks', 'Unveiling secrets behind the masks in a mysterious city.', 2005, 6, 7, 2.50, 160, 'R'),
(49, 'The Forgotten Land', 'Discovering a forgotten land with hidden treasures.', 2016, 1, 12, 4.25, 140, 'PG-13'),
(50, 'Whispers of Wisdom', 'A tale of wisdom and enlightenment.', 2009, 2, 8, 3.75, 125, 'PG');
SET IDENTITY_INSERT Films OFF
---------------------------------2 managers
Insert into Manager (Id)
values
('90aa8cc4-b19f-4d71-9b57-12efd609dam1'),
('90aa8cc4-b19f-4d71-9b57-12efd609dam2');
---------------------------------2 stores
SET IDENTITY_INSERT Stores ON
Insert into Stores (Id, ManagerId, Address)
values
(1, '90aa8cc4-b19f-4d71-9b57-12efd609dam1', 'California USA'),
(2, '90aa8cc4-b19f-4d71-9b57-12efd609dam2', 'LA USA'),
(3, '90aa8cc4-b19f-4d71-9b57-12efd609dam1', 'Isfahan Iran'),
(4, '90aa8cc4-b19f-4d71-9b57-12efd609dam2', 'Tehran Iran');
SET IDENTITY_INSERT Stores OFF	
---------------------------------50 inventory
SET IDENTITY_INSERT Inventories ON
Insert into Inventories (Id, FilmId, StoreId)
Values
(1, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(2, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(3, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(4, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(5, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(6, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(7, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(8, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(9, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(10, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(11, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(12, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(13, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(14, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(15, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(16, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(17, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(18, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(19, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(20, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(21, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(22, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(23, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(24, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(25, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(26, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(27, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(28, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(29, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(30, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(31, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(32, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(33, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(34, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(35, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(36, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(37, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(38, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(39, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(40, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(41, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(42, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(43, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(44, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(45, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(46, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1),
(47, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1), 
(48, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1), 
(49, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1), 
(50, FLOOR(RAND() * 30) + 1, FLOOR(RAND() * 4) + 1);
SET IDENTITY_INSERT Inventories OFF	
-----------------------------------20 actors
SET IDENTITY_INSERT Actors ON	
Insert into Actors (Id, FirstName, LastName)
Values
(1, 'John', 'Doe'),
(2, 'Jane', 'Smith'),
(3, 'Michael', 'Johnson'),
(4, 'Emily', 'Williams'),
(5, 'Robert', 'Brown'),
(6, 'Sophia', 'Jones'),
(7, 'Daniel', 'Miller'),
(8, 'Olivia', 'Davis'),
(9, 'Matthew', 'Wilson'),
(10, 'Emma', 'Moore'),
(11, 'Christopher', 'Taylor'),
(12, 'Ava', 'Anderson'),
(13, 'William', 'Martinez'),
(14, 'Isabella', 'Clark'),
(15, 'Joseph', 'Thomas'),
(16, 'Grace', 'Garcia'),
(17, 'James', 'Hernandez'),
(18, 'Abigail', 'Young'),
(19, 'Benjamin', 'Lopez'),
(20, 'Madison', 'Allen');
SET IDENTITY_INSERT Actors OFF	
-----------------------------------52 filmactors
SET IDENTITY_INSERT FilmActors ON	
Insert into FilmActors(ActorId, FilmId)
Values
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1),
(FLOOR(RAND() * 20) + 1, FLOOR(RAND() * 30) + 1);
SET IDENTITY_INSERT FilmActors OFF
--------------------------10 categories
SET IDENTITY_INSERT Categories ON	
Insert into Categories(Id, Name)
Values
(1, 'Action'),
(2, 'Comedy'),
(3, 'Drama'),
(4, 'Horror'),
(5, 'Science Fiction'),
(6, 'Fantasy'),
(7, 'Adventure'),
(8, 'Romance'),
(9, 'Thriller'),
(10, 'Animation');
SET IDENTITY_INSERT Categories OFF
---------------------------- 50 filmcategory
SET IDENTITY_INSERT FilmCategories ON	

INSERT INTO FilmCategories (Id, CategoryId, FilmId)
VALUES
(1, 3, 1),
(2, 7, 2),
(3, 1, 3),
(4, 9, 4),
(5, 2, 5),
(6, 5, 6),
(7, 8, 7),
(8, 4, 8),
(9, 10, 9),
(10, 6, 10),
(11, 3, 11),
(12, 7, 12),
(13, 1, 13),
(14, 9, 14),
(15, 2, 15),
(16, 5, 16),
(17, 8, 17),
(18, 4, 18),
(19, 10, 19),
(20, 6, 20),
(21, 3, 21),
(22, 7, 22),
(23, 1, 23),
(24, 9, 24),
(25, 2, 25),
(26, 5, 26),
(27, 8, 27),
(28, 4, 28),
(29, 10, 29),
(30, 6, 30),
(31, 3, 31),
(32, 7, 32),
(33, 1, 33),
(34, 9, 34),
(35, 2, 35),
(36, 5, 36),
(37, 8, 37),
(38, 4, 38),
(39, 10, 39),
(40, 6, 40),
(41, 3, 41),
(42, 7, 42),
(43, 1, 43),
(44, 9, 44),
(45, 2, 45),
(46, 5, 46),
(47, 8, 47),
(48, 4, 48),
(49, 10, 49),
(50, 6, 50);

SET IDENTITY_INSERT FilmCategories OFF	
-----------------------------------12 users
Insert into [User](
    Id,
    Name,
    UserName,
    NormalizedUserName,
    Email,
    NormalizedEmail,
    EmailConfirmed,
    PasswordHash,
    SecurityStamp,
    ConcurrencyStamp,
    PhoneNumber,
    PhoneNumberConfirmed,
    TwoFactorEnabled,
    LockoutEnd,
    LockoutEnabled,
    AccessFailedCount
)
Values
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da40',
    'User1',
    'user1',
    'USER1',
    'user1@example.com',
    'USER1@EXAMPLE.COM',
    1,
    'hashed_password_1',
    'security_stamp_1',
    'concurrency_stamp_1',
    '1234567890',
    1,
    0,
    NULL,
    1,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da41',
    'User2',
    'user2',
    'USER2',
    'user2@example.com',
    'USER2@EXAMPLE.COM',
    2,
    'hashed_password_2',
    'security_stamp_2',
    'concurrency_stamp_2',
    '1234567890',
    2,
    0,
    NULL,
    2,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da42',
    'User3',
    'user3',
    'USER3',
    'user3@example.com',
    'USER3@EXAMPLE.COM',
    3,
    'hashed_password_3',
    'security_stamp_3',
    'concurrency_stamp_3',
    '1234567890',
    3,
    0,
    NULL,
    3,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da43',
    'User4',
    'user4',
    'USER4',
    'user4@example.com',
    'USER4@EXAMPLE.COM',
    4,
    'hashed_password_4',
    'security_stamp_4',
    'concurrency_stamp_4',
    '1234567890',
    4,
    0,
    NULL,
    4,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da44',
    'User5',
    'user5',
    'USER5',
    'user5@example.com',
    'USER5@EXAMPLE.COM',
    5,
    'hashed_password_5',
    'security_stamp_5',
    'concurrency_stamp_5',
    '1234567890',
    5,
    0,
    NULL,
    5,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da45',
    'User6',
    'user6',
    'USER6',
    'user6@example.com',
    'USER6@EXAMPLE.COM',
    6,
    'hashed_password_6',
    'security_stamp_6',
    'concurrency_stamp_6',
    '1234567890',
    6,
    0,
    NULL,
    6,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da46',
    'User7',
    'user7',
    'USER7',
    'user7@example.com',
    'USER7@EXAMPLE.COM',
    7,
    'hashed_password_7',
    'security_stamp_7',
    'concurrency_stamp_7',
    '1234567890',
    7,
    0,
    NULL,
    7,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da47',
    'User8',
    'user8',
    'USER8',
    'user8@example.com',
    'USER8@EXAMPLE.COM',
    8,
    'hashed_password_8',
    'security_stamp_8',
    'concurrency_stamp_8',
    '1234567890',
    8,
    0,
    NULL,
    8,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da48',
    'User9',
    'user9',
    'USER9',
    'user9@example.com',
    'USER9@EXAMPLE.COM',
    9,
    'hashed_password_9',
    'security_stamp_9',
    'concurrency_stamp_9',
    '1234567890',
    9,
    0,
    NULL,
    9,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609da49',
    'User10',
    'user10',
    'USER10',
    'user10@example.com',
    'USER10@EXAMPLE.COM',
    10,
    'hashed_password_10',
    'security_stamp_10',
    'concurrency_stamp_10',
    '1234567890',
    10,
    0,
    NULL,
    10,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609dam1',
    'User11',
    'user11',
    'USER11',
    'user11@example.com',
    'USER11@EXAMPLE.COM',
    11,
    'hashed_password_11',
    'security_stamp_11',
    'concurrency_stamp_11',
    '1234567890',
    11,
    0,
    NULL,
    11,
    0
),
(
    '90aa8cc4-b19f-4d71-9b57-12efd609dam2',
    'User12',
    'user12',
    'USER12',
    'user12@example.com',
    'USER12@EXAMPLE.COM',
    12,
    'hashed_password_12',
    'security_stamp_12',
    'concurrency_stamp_12',
    '1234567890',
    12,
    0,
    NULL,
    12,
    0
);
--------------------- 12 UserRole
Insert into UserRoles(RoleId, UserId)
Values
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da40'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da41'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da42'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da43'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da44'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da45'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da46'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da47'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da48'),
('3ba53cbd-20ad-4684-8709-c662customer', '90aa8cc4-b19f-4d71-9b57-12efd609da49'),
('12ef1baa-3601-4c1f-8873-3259bmanager', '90aa8cc4-b19f-4d71-9b57-12efd609dam1'),
('12ef1baa-3601-4c1f-8873-3259bmanager', '90aa8cc4-b19f-4d71-9b57-12efd609dam2');
--------------------- 10 Customers
Insert into Customer(DelayCount, Id)
Values
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da40'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da41'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da42'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da43'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da44'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da45'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da46'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da47'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da48'),
(0, '90aa8cc4-b19f-4d71-9b57-12efd609da49');

----------------------------------- 50 rentals
SET IDENTITY_INSERT Rentals ON	
Insert into Rentals (Id, CustomerId, InventoryId, RentalDate, ReturnDate, Score)
Values
(1, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 15, '2024-01-25T12:00:00', '2024-02-05T12:00:00', 8.5),
(2, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 22, '2024-01-26T14:30:00', '2024-02-08T14:30:00', 7.2),
(3, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 5, '2024-01-27T11:45:00', '2024-02-02T11:45:00', 9.0),
(4, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 31, '2024-01-28T10:20:00', '2024-02-07T10:20:00', 6.8),
(5, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 17, '2024-01-29T16:00:00', '2024-02-12T16:00:00', 8.9),
(6, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 42, '2024-01-30T13:10:00', '2024-02-10T13:10:00', 7.5),
(7, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 8, '2024-01-31T09:30:00', '2024-02-04T09:30:00', 5.6),
(8, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 26, '2024-02-01T08:45:00', '2024-02-11T08:45:00', 9.3),
(9, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 38, '2024-02-02T15:20:00', '2024-02-16T15:20:00', 6.2),
(10, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 49, '2024-02-03T12:15:00', '2024-02-15T12:15:00', 8.0),
(11, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 11, '2024-02-04T14:30:00', '2024-02-18T14:30:00', 7.7),
(12, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 2, '2024-02-05T11:45:00', '2024-02-19T11:45:00', 6.5),
(13, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 33, '2024-02-06T10:20:00', '2024-02-20T10:20:00', 9.1),
(14, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 21, '2024-02-07T16:00:00', '2024-02-21T16:00:00', 5.8),
(15, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 44, '2024-02-08T13:10:00', '2024-02-22T13:10:00', 8.4),
(16, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 16, '2024-02-09T09:30:00', '2024-02-23T09:30:00', 6.9),
(17, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 27, '2024-02-10T08:45:00', '2024-02-24T08:45:00', 9.5),
(18, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 39, '2024-02-11T15:20:00', '2024-02-25T15:20:00', 7.3),
(19, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 50, '2024-02-12T12:15:00', '2024-02-26T12:15:00', 8.7),
(20, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 9, '2024-02-13T14:30:00', '2024-02-27T14:30:00', 5.4),
(21, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 19, '2024-02-14T11:45:00', '2024-02-28T11:45:00', 9.2),
(22, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 30, '2024-02-15T10:20:00', '2024-02-29T10:20:00', 6.1),
(23, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 7, '2024-02-16T16:00:00', '2024-03-01T16:00:00', 8.3),
(24, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 36, '2024-02-17T13:10:00', '2024-03-02T13:10:00', 7.0),
(25, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 48, '2024-02-18T09:30:00', '2024-03-03T09:30:00', 6.6),
(26, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 14, '2024-02-19T08:45:00', '2024-03-04T08:45:00', 8.0),
(27, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 25, '2024-02-20T15:20:00', '2024-03-05T15:20:00', 5.9),
(28, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 37, '2024-02-21T12:15:00', '2024-03-06T12:15:00', 9.0),
(29, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 4, '2024-02-22T14:30:00', '2024-03-07T14:30:00', 7.8),
(30, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 43, '2024-02-23T11:45:00', '2024-03-08T11:45:00', 6.4),
(31, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 20, '2024-02-24T10:20:00', '2024-03-09T10:20:00', 8.6),
(32, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 29, '2024-02-25T16:00:00', '2024-03-10T16:00:00', 7.1),
(33, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 6, '2024-02-26T13:10:00', '2024-03-11T13:10:00', 9.4),
(34, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 1, '2024-01-25T12:00:00', '2024-01-26T12:00:00', 7.5),
(35, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 2, '2024-01-20T14:30:00', '2024-01-21T14:30:00', 4.2),
(36, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 3, '2024-01-22T10:45:00', '2024-01-23T10:45:00', 6.8),
(37, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 4, '2024-01-18T08:15:00', '2024-01-19T08:15:00', 2.0),
(38, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 5, '2024-01-27T16:20:00', '2024-01-28T16:20:00', 5.5),
(39, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 6, '2024-01-24T09:30:00', '2024-01-25T09:30:00', 8.7),
(40, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 7, '2024-01-21T11:00:00', '2024-01-22T11:00:00', 6.2),
(41, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 8, '2024-01-19T13:45:00', '2024-01-20T13:45:00', 1.8),
(42, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 9, '2024-01-26T15:10:00', '2024-01-27T15:10:00', 9.5),
(43, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 10, '2024-01-23T07:30:00', '2024-01-24T07:30:00', 5.0),
(44, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 11, '2024-01-22T14:00:00', '2024-01-23T14:00:00', 2),
(45, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 12, '2024-01-20T09:15:00', '2024-01-21T09:15:00', 6.5),
(46, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 13, '2024-01-18T11:30:00', '2024-01-19T11:30:00', 7.2),
(47, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 14, '2024-01-27T08:45:00', '2024-01-28T08:45:00', 9.1),
(48, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 15, '2024-01-24T16:10:00', '2024-01-25T16:10:00', 5.8),
(49, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 16, '2024-01-21T09:30:00', '2024-01-22T09:30:00', 8.0),
(50, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 17, '2024-01-19T14:00:00', '2024-01-20T14:00:00', 1);
SET IDENTITY_INSERT Rentals OFF;
-------------------------- 60 Payments
SET IDENTITY_INSERT Payments ON;
Insert into Payments (Id, CustomerId, RentalId, Amount)
Values
(1, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 1, 25.75),
(2, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 2, 15.50),
(3, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 3, 30.25),
(4, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 4, 12.99),
(5, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 5, 18.75),
(6, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 6, 22.50),
(7, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 7, 28.99),
(8, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 8, 14.25),
(9, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 9, 19.99),
(10, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 10, 32.50),
(11, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 11, 16.75),
(12, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 12, 21.50),
(13, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 13, 28.25),
(14, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 14, 9.99),
(15, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 15, 24.75),
(16, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 16, 16.50),
(17, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 17, 30.99),
(18, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 18, 12.25),
(19, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 19, 17.99),
(20, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 20, 22.50),
(21, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 21, 15.75),
(22, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 22, 20.50),
(23, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 23, 25.25),
(24, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 24, 14.99),
(25, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 25, 19.75),
(26, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 26, 26.50),
(27, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 27, 32.99),
(28, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 28, 18.25),
(29, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 29, 23.99),
(30, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 30, 28.50),
(31, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 31, 20.75),
(32, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 32, 26.50),
(33, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 33, 32.25),
(34, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 34, 21.99),
(35, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 35, 26.75),
(36, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 36, 30.50),
(37, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 37, 36.99),
(38, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 38, 22.25),
(39, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 39, 27.99),
(40, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 40, 32.50),
(41, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 41, 24.75),
(42, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 42, 30.50),
(43, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 43, 36.25),
(44, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 44, 25.99),
(45, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 45, 30.75),
(46, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 46, 34.50),
(47, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 47, 40.99),
(48, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 48, 26.25),
(49, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 49, 31.99),
(50, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 50, 36.50),
(51, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 1, 25.75),
(52, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 2, 15.50),
(53, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 3, 30.25),
(54, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 4, 12.99),
(55, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 5, 18.75),
(56, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 6, 22.50),
(57, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 7, 28.99),
(58, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 8, 14.25),
(59, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 9, 19.99),
(60, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 10, 32.50);
SET IDENTITY_INSERT Payments OFF;
-----------------------------------  20 Reservations
SET IDENTITY_INSERT Reservations ON;

Insert into Reservations (Id, CustomerId, InventoryId)
Values
(1, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 10),
(2, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 25),
(3, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 5),
(4, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 15),
(5, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 30),
(6, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 20),
(7, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 12),
(8, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 7),
(9, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 1),
(10, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 18),
(11, '90aa8cc4-b19f-4d71-9b57-12efd609da40', 42),
(12, '90aa8cc4-b19f-4d71-9b57-12efd609da41', 11),
(13, '90aa8cc4-b19f-4d71-9b57-12efd609da42', 35),
(14, '90aa8cc4-b19f-4d71-9b57-12efd609da43', 2),
(15, '90aa8cc4-b19f-4d71-9b57-12efd609da44', 28),
(16, '90aa8cc4-b19f-4d71-9b57-12efd609da45', 8),
(17, '90aa8cc4-b19f-4d71-9b57-12efd609da46', 19),
(18, '90aa8cc4-b19f-4d71-9b57-12efd609da47', 33),
(19, '90aa8cc4-b19f-4d71-9b57-12efd609da48', 14),
(20, '90aa8cc4-b19f-4d71-9b57-12efd609da49', 46);
SET IDENTITY_INSERT Reservations OFF;
