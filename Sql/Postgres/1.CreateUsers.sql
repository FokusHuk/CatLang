CREATE TABLE IF NOT EXISTS public."Users"
(
    "Id" uuid NOT NULL,
    "Username" text COLLATE pg_catalog."default" NOT NULL,
    "Login" text COLLATE pg_catalog."default" NOT NULL,
    "PasswordHash" text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "Users_pkey" PRIMARY KEY ("Id")
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public."Users"
    OWNER to postgres;
