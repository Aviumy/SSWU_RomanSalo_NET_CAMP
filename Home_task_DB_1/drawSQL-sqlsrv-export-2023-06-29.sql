CREATE TABLE "Курсові роботи"(
    "id_роботи" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "Номер заліковки студента" BIGINT NULL,
    "id_викладача" BIGINT NOT NULL,
    "id_предмету" BIGINT NOT NULL,
    "Вид роботи" NVARCHAR(255) NOT NULL,
    "Дата затвердження теми" DATE NOT NULL,
    "Дата захисту" DATETIME NOT NULL,
    "Оцінка" TINYINT NULL
);
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_роботи_primary" PRIMARY KEY("id_роботи");
CREATE TABLE "Спеціальності"(
    "id_спеціальності" BIGINT NOT NULL,
    "Код" NVARCHAR(255) NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Спеціальності" ADD CONSTRAINT "Спеціальності_id_спеціальності_primary" PRIMARY KEY("id_спеціальності");
CREATE TABLE "Академ"." групи викладачів"(
    "id_викладача" BIGINT NOT NULL,
    "id_групи" BIGINT NOT NULL,
    "id_предмету" BIGINT NOT NULL
);
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_викладача_primary" PRIMARY KEY("id_викладача");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_групи_primary" PRIMARY KEY("id_групи");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_предмету_primary" PRIMARY KEY("id_предмету");
CREATE TABLE "Академ"." групи"(
    "id_групи" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "id_спеціальності" BIGINT NOT NULL,
    "id_кафедри" BIGINT NOT NULL
);
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_id_групи_primary" PRIMARY KEY("id_групи");
CREATE TABLE "Студенти"(
    "Номер заліковки" BIGINT NOT NULL,
    "Прізвище" NVARCHAR(255) NOT NULL,
    "Ім'я" NVARCHAR(255) NOT NULL,
    "По батькові" NVARCHAR(255) NOT NULL,
    "Курс" TINYINT NOT NULL,
    "id_групи" BIGINT NOT NULL
);
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_Номер заліковки_primary" PRIMARY KEY("Номер заліковки");
CREATE TABLE "Кафедри"(
    "id_кафедри" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "id_факультету" BIGINT NOT NULL
);
ALTER TABLE
    "Кафедри" ADD CONSTRAINT "Кафедри_id_кафедри_primary" PRIMARY KEY("id_кафедри");
CREATE TABLE "Навчальні предмети"(
    "id_предмету" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "К-сть годин" SMALLINT NOT NULL,
    "Іспит/залік" NVARCHAR(255) NOT NULL,
    "id_кафедри" BIGINT NOT NULL
);
ALTER TABLE
    "Навчальні предмети" ADD CONSTRAINT "Навчальні предмети_id_предмету_primary" PRIMARY KEY("id_предмету");
CREATE TABLE "Факультети"(
    "id_факультету" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Факультети" ADD CONSTRAINT "Факультети_id_факультету_primary" PRIMARY KEY("id_факультету");
CREATE TABLE "Викладачі"(
    "id_викладача" BIGINT NOT NULL,
    "Прізвище" NVARCHAR(255) NOT NULL,
    "Ім'я" NVARCHAR(255) NOT NULL,
    "По батькові" NVARCHAR(255) NOT NULL,
    "id_кафедри" BIGINT NOT NULL,
    "Посада" NVARCHAR(255) NOT NULL,
    "Науковий ступінь" NVARCHAR(255) NOT NULL,
    "Вчене звання" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Викладачі" ADD CONSTRAINT "Викладачі_id_викладача_primary" PRIMARY KEY("id_викладача");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_Номер заліковки студента_foreign" FOREIGN KEY("Номер заліковки студента") REFERENCES "Студенти"("Номер заліковки");
ALTER TABLE
    "Навчальні предмети" ADD CONSTRAINT "Навчальні предмети_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id_кафедри");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_викладача_foreign" FOREIGN KEY("id_викладача") REFERENCES "Викладачі"("id_викладача");
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id_кафедри");
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_id_групи_foreign" FOREIGN KEY("id_групи") REFERENCES "Академ"." групи"("id_групи");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_викладача_foreign" FOREIGN KEY("id_викладача") REFERENCES "Викладачі"("id_викладача");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_предмету_foreign" FOREIGN KEY("id_предмету") REFERENCES "Навчальні предмети"("id_предмету");
ALTER TABLE
    "Викладачі" ADD CONSTRAINT "Викладачі_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id_кафедри");
ALTER TABLE
    "Кафедри" ADD CONSTRAINT "Кафедри_id_факультету_foreign" FOREIGN KEY("id_факультету") REFERENCES "Факультети"("id_факультету");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_предмету_foreign" FOREIGN KEY("id_предмету") REFERENCES "Навчальні предмети"("id_предмету");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_групи_foreign" FOREIGN KEY("id_групи") REFERENCES "Академ"." групи"("id_групи");
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_id_спеціальності_foreign" FOREIGN KEY("id_спеціальності") REFERENCES "Спеціальності"("id_спеціальності");