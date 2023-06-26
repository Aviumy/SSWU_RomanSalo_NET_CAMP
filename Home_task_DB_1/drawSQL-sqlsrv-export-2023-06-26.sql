CREATE TABLE "Предмети груп"(
    "Академ"." група" NVARCHAR(255) NOT NULL,
    "id_предмету" BIGINT NOT NULL
);
ALTER TABLE
    "Предмети груп" ADD CONSTRAINT "Предмети груп_Академ_ група_primary" PRIMARY KEY("Академ"." група");
ALTER TABLE
    "Предмети груп" ADD CONSTRAINT "Предмети груп_id_предмету_primary" PRIMARY KEY("id_предмету");
CREATE TABLE "Курсові роботи"(
    "Назва" NVARCHAR(255) NOT NULL,
    "Н заліковки студента" BIGINT NOT NULL,
    "id_викладача" BIGINT NOT NULL,
    "id_факультету" BIGINT NOT NULL,
    "id_предмету" BIGINT NOT NULL,
    "Вид роботи" NVARCHAR(255) NOT NULL,
    "Дата затвердження теми" DATE NOT NULL,
    "Дата захисту" DATETIME NOT NULL,
    "Оцінка" TINYINT NULL
);
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_Назва_primary" PRIMARY KEY("Назва");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_Дата затвердження теми_primary" PRIMARY KEY("Дата затвердження теми");
CREATE TABLE "Спеціальності"(
    "Код" SMALLINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Спеціальності" ADD CONSTRAINT "Спеціальності_Код_primary" PRIMARY KEY("Код");
CREATE TABLE "Академ"." групи викладачів"(
    "id_викладача" BIGINT NOT NULL,
    "Назва групи" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_викладача_primary" PRIMARY KEY("id_викладача");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_Назва групи_primary" PRIMARY KEY("Назва групи");
CREATE TABLE "Академ"." групи"(
    "Назва" NVARCHAR(255) NOT NULL,
    "Код спеціальності" SMALLINT NOT NULL,
    "id_факультету" BIGINT NOT NULL
);
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_Назва_primary" PRIMARY KEY("Назва");
CREATE TABLE "Студенти"(
    "Номер заліковки" BIGINT NOT NULL,
    "Прізвище" NVARCHAR(255) NOT NULL,
    "Ім'я" NVARCHAR(255) NOT NULL,
    "По батькові" NVARCHAR(255) NOT NULL,
    "Код спеціальності" SMALLINT NOT NULL,
    "id_факультету" BIGINT NOT NULL,
    "id_кафедри" BIGINT NULL,
    "Назва академ"." групи" NVARCHAR(255) NOT NULL
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
    "id" BIGINT NOT NULL,
    "Назва" NVARCHAR(255) NOT NULL,
    "Скорочена назва" NVARCHAR(255) NOT NULL,
    "К-сть годин" SMALLINT NOT NULL,
    "Іспит/залік" NVARCHAR(255) NOT NULL,
    "id_кафедри" BIGINT NOT NULL
);
ALTER TABLE
    "Навчальні предмети" ADD CONSTRAINT "Навчальні предмети_id_primary" PRIMARY KEY("id");
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
    "Вчене звання" NVARCHAR(255) NOT NULL
);
ALTER TABLE
    "Викладачі" ADD CONSTRAINT "Викладачі_id_primary" PRIMARY KEY("Id");
CREATE TABLE "Предмети викладачів"(
    "id_викладача" BIGINT NOT NULL,
    "id_предмету" BIGINT NOT NULL
);
ALTER TABLE
    "Предмети викладачів" ADD CONSTRAINT "Предмети викладачів_id_викладача_primary" PRIMARY KEY("id_викладача");
ALTER TABLE
    "Предмети викладачів" ADD CONSTRAINT "Предмети викладачів_id_предмету_primary" PRIMARY KEY("id_предмету");
ALTER TABLE
    "Предмети викладачів" ADD CONSTRAINT "Предмети викладачів_id_предмету_foreign" FOREIGN KEY("id_предмету") REFERENCES "Навчальні предмети"("id");
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_Н заліковки студента_foreign" FOREIGN KEY("Н заліковки студента") REFERENCES "Студенти"("Номер заліковки");
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_id_факультету_foreign" FOREIGN KEY("id_факультету") REFERENCES "Факультети"("id");
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_Назва_foreign" FOREIGN KEY("Назва") REFERENCES "Предмети груп"("Академ"." група");
ALTER TABLE
    "Навчальні предмети" ADD CONSTRAINT "Навчальні предмети_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_id_викладача_foreign" FOREIGN KEY("id_викладача") REFERENCES "Викладачі"("Id");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_факультету_foreign" FOREIGN KEY("id_факультету") REFERENCES "Факультети"("id");
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_Код спеціальності_foreign" FOREIGN KEY("Код спеціальності") REFERENCES "Спеціальності"("Код");
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_Назва академ_ групи_foreign" FOREIGN KEY("Назва академ"." групи") REFERENCES "Академ"." групи"("Назва");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_викладача_foreign" FOREIGN KEY("id_викладача") REFERENCES "Викладачі"("Id");
ALTER TABLE
    "Предмети груп" ADD CONSTRAINT "Предмети груп_id_предмету_foreign" FOREIGN KEY("id_предмету") REFERENCES "Навчальні предмети"("id");
ALTER TABLE
    "Предмети викладачів" ADD CONSTRAINT "Предмети викладачів_id_викладача_foreign" FOREIGN KEY("id_викладача") REFERENCES "Викладачі"("Id");
ALTER TABLE
    "Викладачі" ADD CONSTRAINT "Викладачі_id_кафедри_foreign" FOREIGN KEY("id_кафедри") REFERENCES "Кафедри"("id");
ALTER TABLE
    "Кафедри" ADD CONSTRAINT "Кафедри_id_факультету_foreign" FOREIGN KEY("id_факультету") REFERENCES "Факультети"("id");
ALTER TABLE
    "Курсові роботи" ADD CONSTRAINT "Курсові роботи_id_предмету_foreign" FOREIGN KEY("id_предмету") REFERENCES "Навчальні предмети"("id");
ALTER TABLE
    "Студенти" ADD CONSTRAINT "Студенти_id_факультету_foreign" FOREIGN KEY("id_факультету") REFERENCES "Факультети"("id");
ALTER TABLE
    "Академ"." групи викладачів" ADD CONSTRAINT "Академ_ групи викладачів_Назва групи_foreign" FOREIGN KEY("Назва групи") REFERENCES "Академ"." групи"("Назва");
ALTER TABLE
    "Академ"." групи" ADD CONSTRAINT "Академ_ групи_Код спеціальності_foreign" FOREIGN KEY("Код спеціальності") REFERENCES "Спеціальності"("Код");