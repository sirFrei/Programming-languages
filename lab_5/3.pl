diff([], _, []).
diff([H|T], B, [H|DTail]) :-
    \+ member(H, B),
    diff(T, B, DTail).
diff([H|T], B, DTail) :-
    member(H, B),
    diff(T, B, DTail).

main(A, B, SymDiff) :-
    diff(A, B, D1),
    diff(B, A, D2),
    append(D1, D2, SymDiff).

% Пример использования:
% ?- main([1,2,3,4], [3,4,5,6], X).
% X = [1,2,5,6].
