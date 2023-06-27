if not exists(select  * from sys.databases where name = 'Discordia')
    CREATE DATABASE Discordia

go
use Discordia

CREATE TABLE Person(
    id int PRIMARY KEY not null IDENTITY(1,1),
    name varchar(100) not null,
    birth date not null,
    email varchar(50) not null,
    photo varchar(100) not null, 
    password varchar(100) not null,
    salt varchar(50) not null
)


GO
CREATE TABLE Forum(
    id int PRIMARY KEY not  null IDENTITY(1,1),
    creator_id int not null,
    title varchar(50),
    created date,
    description varchar(500),
    CONSTRAINT fk_creator_ID
        FOREIGN KEY (creator_id)
        REFERENCES Person(id)
)



GO
CREATE TABLE Funcs(
    id int PRIMARY KEY not  null IDENTITY(1,1),
    name varchar(40) not null
)


GO
CREATE TABLE Position(
    id int PRIMARY KEY not  null IDENTITY(1,1),
    name VARCHAR(20),
    id_forum int FOREIGN KEY (id_forum) REFERENCES Forum(id)
)

GO
CREATE TABLE Permission(
    id int PRIMARY KEY not  null IDENTITY(1,1),
    id_funcs int FOREIGN KEY (id_funcs) REFERENCES Funcs(id),
    id_position int FOREIGN KEY (id_position) REFERENCES Position(id)
)

GO
CREATE TABLE Subscribed(
    id int PRIMARY KEY not  null IDENTITY(1,1),
    id_person int FOREIGN KEY (id_person) REFERENCES Person(id),
    id_position int FOREIGN KEY (id_position) REFERENCES Position(id)
)

GO
CREATE TABLE Post(
    id int PRIMARY KEY not null IDENTITY(1,1),
    title varchar(50),
    content varchar(500),
    createdAt date default GETDATE(),
    attachment bit,
    id_forum int FOREIGN key (id_forum) REFERENCES Forum(id),
    id_creator int FOREIGN KEY (id_creator) REFERENCES Person(id)
)

GO
CREATE table Likes(
    id int PRIMARY KEY not null IDENTITY(1,1),
    positive bit not null,
    id_person int not null FOREIGN KEY (id_person) REFERENCES Person(id),
    id_post int not null FOREIGN KEY (id_post) REFERENCES Post(id),
)

GO 
CREATE table  Comments(
    id int PRIMARY KEY not null IDENTITY(1,1),
    comment varchar(100) not null,
    id_person int not null FOREIGN KEY (id_person) REFERENCES Person(id),
    id_post int not null FOREIGN KEY (id_post) REFERENCES Post(id),
)
