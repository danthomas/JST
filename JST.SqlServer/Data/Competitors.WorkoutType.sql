
set identity_insert Competitors.WorkoutType on

insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (1, 'Am Cardio', 1)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (2, 'Am Lift', 2)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (3, 'Pm Lift', 3)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (4, 'Pm Gymnastics', 4)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (5, 'Pm Metcon',5 )
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (6, 'Core', 6)

set identity_insert Competitors.WorkoutType off