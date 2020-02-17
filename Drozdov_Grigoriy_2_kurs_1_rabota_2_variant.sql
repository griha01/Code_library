Create database Base7 COLLATE='utf8_unicode_ci';
use Base7;
DROP TABLE IF EXISTS `Аттестация`;
DROP TABLE IF EXISTS `Студент`;
DROP TABLE IF EXISTS `Дисциплина специальности`;
DROP TABLE IF EXISTS `Дисциплина`;
DROP TABLE IF EXISTS `Группы`;

  CREATE TABLE `Дисциплина` (
  `Код дисциплины` int primary key,
  `Название дисциплины` varchar(25) not null
  );
  CREATE TABLE `Группы` (
  `№ группы` varchar(10) primary key,
  `Название группы` varchar(25) not null
  );
  CREATE TABLE `Дисциплина специальности` (
  `Код дисциплины` int,
  `№ группы` varchar(10),
  `Лекция` int  NULL,
  `Практика` int  NULL,
  `Зачет/Экзамен` boolean, 
  primary key(`Код дисциплины`,`№ группы`),
  FOREIGN KEY (`Код дисциплины`) REFERENCES `Дисциплина`(`Код дисциплины`) ON DELETE NO ACTION ON UPDATE CASCADE,
  FOREIGN KEY (`№ группы`) REFERENCES `Группы`(`№ группы`) ON DELETE NO ACTION ON UPDATE CASCADE
  );
  CREATE TABLE `Студент` (
  `№ зачетки` int PRIMARY KEY,
  `ФИО студента` VARCHAR(35) not NULL,
  `№ группы` varchar(10) not NULL,
  FOREIGN KEY (`№ группы`) REFERENCES `Группы`(`№ группы`) ON DELETE NO ACTION ON UPDATE CASCADE
  );
  CREATE TABLE `Аттестация` (
  `№ зачетки` int not null,
  `Дата сдачи` date not null,
  `Код дисциплины` int not null,
  `Оценка` int null,
  FOREIGN KEY (`№ зачетки`) REFERENCES `Студент`(`№ зачетки`) ON DELETE NO ACTION ON UPDATE CASCADE
  );
create view ogran(`№ зачетки`,`Дата сдачи`,`Код дисциплины`,`Оценка`) as
select `Аттестация`.`№ зачетки`,`Дата сдачи`,`Аттестация`.`Код дисциплины`
from (`Аттестация` inner join `Студент` on `Аттестация`.`№ зачетки` = `Студент`.`№ зачетки`) inner join `Дисциплина специальности` on `Дисциплина специальности`.`№ группы` = `Студент`.`№ группы` and  `Дисциплина специальности`.`Код дисциплины`=`Аттестация`.`Код дисциплины`;
/*Заполняет*/
insert into ogran
values (1,'ИВТ-101',1);


