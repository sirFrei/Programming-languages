main(N, Num) :-
    integer(N), N >= 0,
    number_codes(N, Cods), 
    maplist(code_digit, Cods, Num).

code_digit(Code, Digit) :-
    Digit is Code - 0'0.

%?- main(81837, X)
