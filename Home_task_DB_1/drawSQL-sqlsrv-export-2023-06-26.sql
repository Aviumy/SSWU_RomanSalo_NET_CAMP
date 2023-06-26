CREATE TABLE "Курсові роботи"(
    "id" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "id_студента" BIGINT NOT NULL,
    "id_викладача" BIGINT NOT NULL,
    "id_факультету" BIGINT NOT NULL,
    "Назва предмету" NVARCHAR(255) NOT NULL,
    "Вид роботи" NVARCHAR(255) NOT NULL,
    "Дата затвердження теми" DATE NOT NULL,
    "Дата захисту" DATETIME NOT NULL
);
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_primary" PRIMARY KEY("id");
CREATE TABLE "Спеціальності"(
    "Код" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Спеціальності" ADD CONSTRAINT "Спеціальності_Код_primary" PRIMARY KEY("Код");
CREATE TABLE "Академ"." групи"("Назва" NVARCHAR(255) NOT NULL);
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_Назва_primary" PRIMARY KEY("Назва");
CREATE TABLE "Студенти"(
    "Номер заліковки" BIGINT NOT NULL,
    "Прізвище" NVARCHAR(255) NOT NULL,
    "Ім'я" NVARCHAR(255) NOT NULL,
    "По батькові" NVARCHAR(255) NOT NULL,
    "id_факультету" BIGINT NOT NULL,
    "Код спеціальності" BIGINT NOT NULL,
    "Назва академ"." групи" NVARCHAR(255) NOT NULL,
    "Вид академ"." стипендії" NVARCHAR(255) NOT NULL,
    "Соц"." стипендія (чи є)" TINYINT NOT NULL
);
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_Номер заліковки_primary" PRIMARY KEY("Номер заліковки");
CREATE TABLE "Кафедри"(
    "id" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "id_факультету" BIGINT NOT NULL
);
ALTER TABLE
    "Кафедри" ADD CONSTRAINT "Кафедри_id_primary" PRIMARY KEY("id");
CREATE TABLE "Навчальні предмети"(
    "Назва" NVARCHAR(255) NOT NULL,
    "Скорочена назва" NVARCHAR(255) NOT NULL,
    "К-сть годин" SMALLINT NOT NULL,
    "Іспит/залік" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Навчальні предмети" ADD CONSTRAINT "Навчальні предмети_Назва_primary" PRIMARY KEY("Назва");
CREATE TABLE "Здані курсові роботи"(
    "id" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "id_студента" BIGINT NOT NULL,
    "id_викладача" BIGINT NOT NULL,
    "id_факультету" BIGINT NOT NULL,
    "Назва предмету" NVARCHAR(255) NOT NULL,
    "Вид роботи" NVARCHAR(255) NOT NULL,
    "Дата затвердження теми" DATE NOT NULL,
    "Дата захисту" DATETIME NOT NULL,
    "Оцінка" TINYINT NOT NULL
);
ALTER TABLE
    "Здані курсові роботи" ADD CONSTRAINT "Здані курсові роботи_id_primary" PRIMARY KEY("id");
CREATE TABLE "Факультети"(
    "id" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Факультети" ADD CONSTRAINT "Факультети_id_primary" PRIMARY KEY("id");
CREATE TABLE "Викладачі"(
    "Id" BIGINT NOT NULL,
    "Прізвище" NVARCHAR(255) NOT NULL,
    "Ім'я" NVARCHAR(255) NOT NULL,
    "По батькові" NVARCHAR(255) NOT NULL,
    "id_кафедри" BIGINT NOT NULL,
    "Посада" NVARCHAR(255) NOT NULL,
    "Науковий ступінь" NVARCHAR(255) NOT NULL,
    "Вчене звання" NVARCHAR(255) NOT NULL,
    "Зарплата" DECIMAL(8, 2) NOT NULL
);
ALTER TABLE
    "Викладачі" ADD CONSTRAINT "Викладачі_id_primary" PRIMARY KEY("Id");