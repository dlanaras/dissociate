-- -----------------------------------------------------
-- Create table dissociate.users
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_user (
    id_user INT NOT NULL AUTO_INCREMENT,
    password VARCHAR(255) NOT NULL,
    username VARCHAR(16) NOT NULL,
    email VARCHAR(255) NOT NULL,
    UNIQUE INDEX email_UNIQUE (email ASC) VISIBLE,
    PRIMARY KEY (id_user)
);
-- -----------------------------------------------------
-- Create table dissociate.tbl_user_role
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_friendaccount (
    id_user INT NOT NULL,
    id_friend INT NOT NULL,
    PRIMARY KEY (id_user, id_friend),
    INDEX fk_tbl_user_has_tbl_user_tbl_user1_idx (id_friend ASC) VISIBLE,
    INDEX fk_tbl_user_has_tbl_user_tbl_user_idx (id_user ASC) VISIBLE,
    FOREIGN KEY (id_user) REFERENCES tbl_user (id_user) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_friend) REFERENCES tbl_user (id_user) ON DELETE NO ACTION ON UPDATE NO ACTION
);
-- -----------------------------------------------------
-- Create table dissociate.tbl_user_role
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS tbl_messages (
    id_message INT NOT NULL AUTO_INCREMENT,
    id_receiveUser INT NOT NULL,
    id_sendUser INT NOT NULL,
    messageContent VARCHAR(255) NOT NULL,
    sendTime DATETIME NULL,
    PRIMARY KEY (id_message),
    INDEX fk_tbl_user_has_tbl_user_tbl_user3_idx (id_sendUser ASC) VISIBLE,
    INDEX fk_tbl_user_has_tbl_user_tbl_user2_idx (id_receiveUser ASC) VISIBLE,
    FOREIGN KEY (id_receiveUser) REFERENCES tbl_user (id_user) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (id_sendUser) REFERENCES tbl_user (id_user) ON DELETE NO ACTION ON UPDATE NO ACTION
);