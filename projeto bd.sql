CREATE DATABASE registro;
USE registro;
DESCRIBE user_tb;
CREATE TABLE user_tb(
	id_user INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    usuario VARCHAR(20) NOT NULL,
    senha VARCHAR(16) NOT NULL
);
INSERT INTO user_tb (usuario, senha) VALUES ('admin', '1234');
SELECT * FROM user_tb;
ALTER TABLE user_tb 
ADD COLUMN email VARCHAR(40),
ADD COLUMN documento VARCHAR(21);
