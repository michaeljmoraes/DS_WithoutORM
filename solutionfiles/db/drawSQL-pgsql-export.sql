CREATE TABLE "user_profile"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "id_role" BIGINT NOT NULL,
    "password" VARCHAR(255) NOT NULL,
    "last_login" DATE NULL,
    "is_superuser" BOOLEAN NOT NULL,
    "username" VARCHAR(255) NOT NULL,
    "first_name" VARCHAR(255) NOT NULL,
    "last_name" VARCHAR(255) NOT NULL,
    "email" VARCHAR(255) NOT NULL,
    "is_active" BOOLEAN NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);
ALTER TABLE
    "user_profile" ADD CONSTRAINT "user_profile_username_unique" UNIQUE("username");
CREATE TABLE "document"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "id_owner" BIGINT NOT NULL,
    "id_category" BIGINT NOT NULL,
    "name" VARCHAR(255) NOT NULL,
    "description" VARCHAR(255) NOT NULL,
    "file_name" VARCHAR(255) NOT NULL,
    "file_path" VARCHAR(255) NOT NULL,
    "is_public" BOOLEAN NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);
CREATE TABLE "user_group"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "id_user" BIGINT NOT NULL,
    "id_group" BIGINT NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);

CREATE TABLE "group"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "id_role" BIGINT NOT NULL,
    "name" VARCHAR(255) NOT NULL,
    "description" VARCHAR(255) NULL,
    "is_active" BOOLEAN NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);

CREATE TABLE "role"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "name" VARCHAR(255) NOT NULL,
    "description" VARCHAR(255) NOT NULL,
    "role_type" VARCHAR(255) NOT NULL,
    "domain" VARCHAR(255) NOT NULL,
    "action" VARCHAR(255) NOT NULL,
    "is_active" BOOLEAN NOT NULL,
    "priority" INTEGER NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);

CREATE TABLE "category"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "name" VARCHAR(255) NOT NULL,
    "description" VARCHAR(255) NOT NULL,
    "created_at" DATE NOT NULL,
    "updated_at" DATE NOT NULL
);
CREATE TABLE "download_history"(
    "id" BIGINT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    "id_document" BIGINT NOT NULL,
    "id_user" BIGINT NOT NULL,
    "downloaded_at" DATE NOT NULL
);
ALTER TABLE
    "user_group" ADD CONSTRAINT "user_group_id_user_foreign" FOREIGN KEY("id_user") REFERENCES "user_profile"("id");
ALTER TABLE
    "document" ADD CONSTRAINT "document_id_owner_foreign" FOREIGN KEY("id_owner") REFERENCES "user_profile"("id");
ALTER TABLE
    "user_profile" ADD CONSTRAINT "user_profile_id_role_foreign" FOREIGN KEY("id_role") REFERENCES "role"("id");
ALTER TABLE
    "document" ADD CONSTRAINT "document_id_category_foreign" FOREIGN KEY("id_category") REFERENCES "category"("id");
ALTER TABLE
    "user_group" ADD CONSTRAINT "user_group_id_group_foreign" FOREIGN KEY("id_group") REFERENCES "group"("id");
ALTER TABLE
    "group" ADD CONSTRAINT "group_id_role_foreign" FOREIGN KEY("id_role") REFERENCES "role"("id");
ALTER TABLE
    "download_history" ADD CONSTRAINT "download_history_id_document_foreign" FOREIGN KEY("id_document") REFERENCES "document"("id");
ALTER TABLE
    "download_history" ADD CONSTRAINT "download_history_id_user_foreign" FOREIGN KEY("id_user") REFERENCES "user_profile"("id");


insert INTO ROLE
  (name, description, role_type, domain, action, is_active, priority, created_at, updated_at)
  VALUES
  ('admin', '', 'admin', '', 'action', TRUE, 1, now(), now());