CREATE TABLE IF NOT EXISTS public."Users"
(
    "Id" uuid NOT NULL,
    "Username" character(50)[] COLLATE pg_catalog."default" NOT NULL,
    "Login" character(50)[] COLLATE pg_catalog."default" NOT NULL,
    "PasswordHash" character(1)[] COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Users"
    OWNER to postgres;
