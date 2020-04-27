Create database Base777 COLLATE='utf8_unicode_ci';
use Base777;
DROP TABLE IF EXISTS `Ингредиенты`;
DROP TABLE IF EXISTS `Рецепты`;
DROP TABLE IF EXISTS `Продукты`;

CREATE TABLE `Продукты`(
	`№ позиции` INT NOT NULL,
	`Наименование продукта` VARCHAR(20) NOT NULL,
	`Единицы измерения` VARCHAR(10) NOT NULL,
	PRIMARY KEY (`№ позиции`)
);

CREATE TABLE `Рецепты`(
	`№ рецепта` INT NOT NULL,
	`Название блюда` VARCHAR(60) NOT NULL,
	`Количество ингредиентов`  INT not null default 0,
	PRIMARY KEY (`№ рецепта`)
);

CREATE TABLE `Ингредиенты`(
	`№ рецепта` INT NOT NULL,
	`Номенклатурный №` INT NOT NULL,
	`Количество` float NOT NULL,
	PRIMARY KEY (`№ рецепта`,`Номенклатурный №`),
	FOREIGN KEY (`Номенклатурный №`) REFERENCES `Продукты` (`№ позиции`) ON UPDATE CASCADE ON DELETE restrict,
	FOREIGN KEY (`№ рецепта`) REFERENCES `Рецепты` (`№ рецепта`) ON UPDATE CASCADE ON DELETE restrict
);

INSERT INTO `Продукты` (`№ позиции`,`Наименование продукта`,`Единицы измерения`) VALUES 
	(100, 'Мидия', 'кг'),
	(101, 'Лук', 'кг'),
	(102, 'Сыр', 'граммы'),
	(103, 'Майонез', 'кг'),
	(105, 'Кальмары', 'кг'),
	(106, 'Яйцо куриное', 'шт'),
	(107, 'Огурец соленый', 'кг'),
	(108, 'Яблоки', 'кг'),
	(109, 'Дыня', 'кг');

INSERT INTO `Рецепты` (`№ рецепта`,`Название блюда`) VALUES
	(101,'Салат с кальмарами'),
	(103,'Жульен с мидиями'); 
INSERT INTO `Ингредиенты`(`№ рецепта`,`Номенклатурный №`,`Количество`) VALUES
	(103,100,0.340),
	(103,101,0.100),
	(103,102,0.080),
	(103,103,0.100),
	(101,105,0.300),
	(101,106,3),
	(101,107,0.150),
	(101,108,0.300);

/* 2 */
delimiter //
create function getCount(number int) returns int
deterministic
begin
declare s int;
select count(`№ рецепта`) into s from `Ингредиенты` where `№ рецепта`=number;
return ifnull(s, 0);
end//
delimiter ;	
	
select * from `Ингредиенты`;
select getCount(103);

/* 3 */
delimiter //
create procedure setCount()
begin
update `Рецепты` set `Количество`=getCount(`№ рецепта`);
end//
delimiter ;

CALL setCount();
SELECT * FROM `Рецепты`;

/* 4 */
delimiter // 
create procedure `setCursor`() 
BEGIN 
	DECLARE n char(4);
    DECLARE s, b INT default 0; 
	DECLARE cur1 CURSOR FOR SELECT `№ рецепта`, count(`№ рецепта`) FROM `Ингредиенты` group by `№ рецепта`;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET b = 1; 
    update `Рецепты` set `Количество ингредиентов`=0;
	OPEN cur1; 
    WHILE b = 0 DO 
        FETCH cur1 INTO n, s; 
		update `Рецепты` set `Количество ингредиентов`=s where `№ рецепта`=n;
    END WHILE; 
    CLOSE cur1; 
END // 
delimiter ;

call setCursor();
select * from `Рецепты`;





