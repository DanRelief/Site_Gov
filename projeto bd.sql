CREATE DATABASE IF NOT EXISTS registro;
USE registro;
## DROP TABLE user_tb; USAR APENAS PARA CRIAR  USER

CREATE TABLE user_tb(
	id_user INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(20),
    senha VARCHAR(20),
    email VARCHAR(100),
    documento VARCHAR(20)
);

-- evita duplicar admin
INSERT INTO user_tb (usuario, senha)
SELECT 'admin', '1234'
WHERE NOT EXISTS (
    SELECT 1 FROM user_tb WHERE usuario = 'admin'
);

-- usuário do banco
CREATE USER IF NOT EXISTS 'appuser'@'localhost' IDENTIFIED BY '1234';
ALTER USER 'appuser'@'localhost' IDENTIFIED BY '1234';
GRANT ALL PRIVILEGES ON registro.* TO 'appuser'@'localhost';
FLUSH PRIVILEGES;

SELECT * FROM user_tb;