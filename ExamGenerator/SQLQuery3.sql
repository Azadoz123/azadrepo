use ExamDb
INSERT INTO Exams ( ExamName ) values ( 'Matematik')

INSERT INTO Teacher( TeacherName, ExamId) values ( 'Mehmet', 1)
INSERT INTO Teacher( TeacherName, ExamId) values ( 'Ahmet', 1)
INSERT INTO Teacher( TeacherName, ExamId) values ( 'Ayşe', 1)

insert into Student ( studentName ) values ( 'Halil')
insert into Student ( studentName ) values ('Cemre')
insert into Student ( studentName ) values ('Gizem')

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisi asal sayıdır?', 0, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('2', 'A', 1, 1)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('4', 'B', 0, 1)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('6', 'C', 0, 1)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('8', 'D', 0, 1)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('3x6 işleminin sonucu kaçtır', 0, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('9', 'A', 0, 2)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('18', 'B', 1, 2)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('22', 'C', 0, 2)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('30', 'D', 0, 2)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisi çift sayıdır?', 1, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('1', 'A', 0, 3)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('11', 'B', 0, 3)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('24', 'C', 1, 3)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('33', 'D', 0, 3)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Pi sayısı kaçtır?', 1, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('1', 'A', 0, 4)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('45', 'B', 0, 4)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('2,9', 'C', 0, 4)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('3,14', 'D', 1, 4)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisi 3''e bölünmez?', 2, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('8', 'A', 1, 5)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('63', 'B', 0, 5)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('15', 'C', 0, 5)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('90', 'D', 0, 5)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisi 4''e bölünmez?', 2, 1 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('6', 'A', 1, 6)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('4', 'B', 0, 6)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('8', 'C', 0, 6)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('12', 'D', 0, 6)


INSERT INTO Exams ( ExamName ) values ( 'Türkçe')

INSERT INTO Teacher( TeacherName, ExamId) values ( 'Ali', 2)
INSERT INTO Teacher( TeacherName, ExamId) values ( 'Fatma', 2)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdaki harflerden hangisi alfabemizde yer almaz?', 0, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('A', 'A', 0, 7)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('K', 'B', 0, 7)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('X', 'C', 1, 7)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('Z', 'D', 0, 7)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisinde alfabemizin ilk ve son harfi verilmiştir?', 0, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('B-Ş', 'A', 0, 8)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('A-Z', 'B', 1, 8)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('D-P', 'C', 0, 8)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('B-Ö', 'D', 0, 8)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisinde kalın ünlü harfler verilmiştir?', 1, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('a , ı , o , u', 'A', 1, 9)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('e , i , ö , ü', 'B', 0, 9)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('a , e , ı , i', 'C', 0, 9)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('o , e , ü , i', 'D', 0, 9)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values (' ''Kitap okumayı seviyorum. '' cümlesi kaç kelimeden oluşmuştur ?', 1, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('1', 'A', 0, 10)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('2', 'B', 0, 10)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('3', 'C', 1, 10)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('4', 'D', 0, 10)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıdakilerden hangisi tek hecelidir ?', 2, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('YAT', 'A', 0, 11)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('ARABA', 'B', 0, 11)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('UÇAK', 'C', 1, 11)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('OTOBÜS', 'D', 0, 11)

insert into Questions (QuestionContent, DegreeOfDifficulty, ExamId ) values ('Aşağıda verilen kelimelerden hangisinin harf sayısı diğerlerinden daha azdır ?', 2, 2 )

insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('SARI', 'A', 1, 12)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('SAKSI', 'B', 0, 12)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('SABUN', 'C', 0, 12)
insert into QuestionOptions(QuestionOptionContent, ChoiceOption, ResponseStatus, QuestionId) values ('SAKIZ', 'D', 0, 12)


select * from dbo.Exams
select * from dbo.Teacher
select * from dbo.Questions
select * from dbo.QuestionOptions
select * from dbo.Student