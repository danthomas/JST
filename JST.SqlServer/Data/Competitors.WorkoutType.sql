
set identity_insert Competitors.WorkoutType on

insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (1, 'AmCardio', 1)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (2, 'AmLift', 2)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (3, 'PmLift', 3)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (4, 'PmGymnastics', 4)
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (5, 'PmMetcon',5 )
insert into Competitors.WorkoutType (WorkoutTypeId, Name, SortOrder) values (6, 'Core', 6)

set identity_insert Competitors.WorkoutType off