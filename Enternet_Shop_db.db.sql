BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Internet.shop" (
	"id"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Adres"	TEXT NOT NULL UNIQUE,
	PRIMARY KEY("id" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "product" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	INTEGER NOT NULL,
	"Cost"	INTEGER NOT NULL,
	"Quanity"	INTEGER NOT NULL,
	"Categories"	TEXT NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "product category" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "employee" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Surname"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Patronymic"	TEXT,
	"Date of birth"	INTEGER NOT NULL,
	"Gender"	TEXT NOT NULL,
	"Experience"	INTEGER NOT NULL,
	"Work schedule"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "post" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	TEXT NOT NULL,
	"Salary"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "client" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Surname"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"Patronymic"	TEXT,
	"date of birth"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "discount" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	INTEGER NOT NULL,
	"discount percentage"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "status " (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Name"	INTEGER NOT NULL,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "warehouse" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"warehouse address"	TEXT NOT NULL,
	""	INTEGER,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "order" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"Number"	INTEGER NOT NULL,
	"date"	INTEGER NOT NULL,
	"ID status"	INTEGER NOT NULL UNIQUE,
	"ID client"	INTEGER NOT NULL UNIQUE,
	FOREIGN KEY("ID client") REFERENCES "client"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY("ID status") REFERENCES "status " ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
CREATE TABLE IF NOT EXISTS "delivery" (
	"ID"	INTEGER NOT NULL UNIQUE,
	"adress"	TEXT NOT NULL,
	"ID order"	INTEGER NOT NULL UNIQUE,
	"ID warehouse"	INTEGER NOT NULL UNIQUE,
	FOREIGN KEY("ID order") REFERENCES "order"("ID") ON DELETE CASCADE ON UPDATE CASCADE,
	PRIMARY KEY("ID" AUTOINCREMENT)
);
INSERT INTO "Internet.shop" ("id","Name","Adres") VALUES (1,'AraratShop','г.Москва,ул.Фрунзе 13');
INSERT INTO "product" ("ID","Name","Cost","Quanity","Categories") VALUES (1,'Футболка',1500,500,'одежда'),
 (2,'коньяк"Арарат"',5000,300,'алкоголь'),
 (3,'сувенир"Гранат"',2500,250,'аксессуары'),
 (4,'сыр"Чанах"',1900,450,'молочные продукты'),
 (5,'куртка"Армения"',3500,400,'одежда верхняя');
INSERT INTO "product category" ("ID","Name") VALUES (1,'одежда'),
 (2,'алкоголь'),
 (3,'продукты'),
 (4,'аксессуары'),
 (5,'украшения');
INSERT INTO "employee" ("ID","Surname","Name","Patronymic","Date of birth","Gender","Experience","Work schedule") VALUES (1,'Самойлова','Оксана','Валерьевна','05.06.1995','женский','5 лет','2/2'),
 (2,'Асатрян','Валерия ','Арменовна','01.02.2000','женский','2 года','2/2'),
 (3,'Кириллова','Арина','Геннадьевна','04.03.1980','женский','10 лет','2/2'),
 (4,'Морозова ','Дарья','Сергеевна','02.02.1996','женский','5 лет','2/2'),
 (5,'Дмитриев','Олег','Андреевич','13.12.1997','мужской','7 лет','2/2');
INSERT INTO "post" ("ID","Name","Salary") VALUES (1,'Продавец-консультант',30),
 (2,'Бухгалтер',45),
 (3,'сборщик товаров',35),
 (4,'Охрана',25),
 (5,'Доставщик',50);
INSERT INTO "client" ("ID","Surname","Name","Patronymic","date of birth") VALUES (1,'Масаев','Кирилл','Николаевич','23.12.2003'),
 (2,'Морозова ','Татьяна ','Андреевна','15.02.2000'),
 (3,'Смирнов ','Олег','Романович','10.10.1999'),
 (4,'Романова','Юлия','Олеговна','05.06.1997'),
 (5,'Краснова','Евгения','Кирилловна','11.07.1890');
INSERT INTO "discount" ("ID","Name","discount percentage") VALUES (1,'black friday','13%'),
 (2,'haloween','25%'),
 (3,'vardavar','50%'),
 (4,'happy bithday','90%'),
 (5,'New Year','45%');
INSERT INTO "status " ("ID","Name") VALUES (1,'заказ создан'),
 (2,'заказ собран'),
 (3,'товары отправлены'),
 (4,'можно забрать'),
 (5,'получено');
INSERT INTO "warehouse" ("ID","warehouse address","") VALUES (1,'​МОСКВА-СОКОЛ, Ленинградский проспект, 80 к24, Москва',NULL),
 (2,'Сельскохозяйственная улица, 16а, Москва​',NULL),
 (3,'Улица Сущёвский Вал, 16 ст4, Москва​',NULL),
 (4,'​Егорьевская улица, 7 ст10, Москва',NULL),
 (5,'​Покровский бульвар, 3 ст7, Москва',NULL);
INSERT INTO "order" ("ID","Number","date","ID status","ID client") VALUES (1,578664,'10.11.2023',1,1),
 (2,18936745,'02.01.2022',2,2),
 (3,3457238283,'01.04.2022',3,3),
 (4,2315442358902,'05.04.2022',4,4),
 (5,134546574744,'05.05.2022',5,5);
INSERT INTO "delivery" ("ID","adress","ID order","ID warehouse") VALUES (1,'Огородный проезд, 6, Москва',1,1),
 (2,'​Улица Беговая, 20 к2, Москва',2,2),
 (3,'​1-й Лучевой просек, 7 ст3, Москва',3,3),
 (4,'​Универмаг Московский, Комсомольская площадь, 6, Москва',4,4),
 (5,'​Платформа Северянин, вл14 ст1, Москва',5,5);
COMMIT;
