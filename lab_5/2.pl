main(List, Count) :-
    List \= [],                    
    min_list(List, Min),           
    errs(List, Min, Count).


errs([], _, 0).

errs([H|T], Elem, Count) :-
    H =:= Elem,                    
    errs(T, Elem, C1),
    Count is C1 + 1.

errs([H|T], Elem, Count) :-
    H =\= Elem,                   
    errs(T, Elem, Count).


%test: main([5,2,7,2,9,1,2,1,1], C).