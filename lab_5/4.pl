:- dynamic user_input/1.

% Основная программа
main :-
    solve(Positions),
    write('Распределение мест:'), nl,
    write_teams([spartak, cska, dynamo, rotor], Positions).

% Решение задачи
solve(Positions) :-
    Positions = [S, C, D, R],
    permutation([1,2,3,4], Positions),
    check_ivan(S, C),
    check_sergei(S, C),
    check_petr(D, C),
    check_alexey(D, R).

% Условия для каждого болельщика
check_ivan(S, C) :-
    ( S =:= 1 -> Ivan1 is 1 ; Ivan1 is 0 ),
    ( C =:= 4 -> Ivan2 is 1 ; Ivan2 is 0 ),
    SumIvan is Ivan1 + Ivan2,
    SumIvan =:= 1.

check_sergei(S, C) :-
    ( S >= 3 -> SCond is 1 ; SCond is 0 ),
    ( C =:= 2 -> CCond is 1 ; CCond is 0 ),
    SumS is SCond + CCond,
    SumS =:= 1.

check_petr(D, C) :-
    ( D =:= 1 -> DCond is 1 ; DCond is 0 ),
    ( C =< 3 -> CCond is 1 ; CCond is 0 ),
    SumP is DCond + CCond,
    SumP =:= 1.

check_alexey(D, R) :-
    ( D =:= 2 -> DCond is 1 ; DCond is 0 ),
    ( R =:= 4 -> RCond is 1 ; RCond is 0 ),
    SumA is DCond + RCond,
    SumA =:= 1.

% Вспомогательные предикаты
permutation([], []).
permutation(List, [X|Perm]) :-
    select(X, List, Rest),
    permutation(Rest, Perm).

write_teams([], []).
write_teams([Team|Teams], [Pos|Positions]) :-
    write(Team), write(' - '), write(Pos), nl,
    write_teams(Teams, Positions).