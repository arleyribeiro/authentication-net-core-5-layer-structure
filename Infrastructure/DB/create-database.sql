CREATE DATABASE testdb;

-- \c testedb;

CREATE TABLE accounts (
 id serial PRIMARY KEY,
 username VARCHAR ( 50 ) UNIQUE NOT NULL,
 password VARCHAR ( 500 ) NOT NULL,
 role VARCHAR ( 30 ) NOT NULL,
 created_on TIMESTAMP NOT NULL
);