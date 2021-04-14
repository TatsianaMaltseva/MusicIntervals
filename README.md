# MusicIntervals
Count intervals between notes in ascending and descending order.

method IntervalConstruction

The function 'intervalConstruction' must take an array of strings as input and return a string.
An array contains three or two elements.
The first element in an array is an interval name, the second is a starting note, and the third indicates whether an interval is ascending or descending.
If there is no third element in an array, the building order is ascending by default.
The function should return a string containing a note name.
Only the following note names are allowed in a return string:
Cbb Cb C C# C## Dbb Db D D# D## Ebb Eb E E# E## Fbb Fb F F# F## Gbb Gb G G# G## Abb Ab A A# A## Bbb Bb B B# B##
If there are more or fewer elements in the input array, an exception should be thrown: "Illegal number of elements in input array"

['M3', 'A', 'asc'] - build an ascending M3 interval starting from A
['m7, 'Fb', 'dsc'] - build an descending m7 interval starting from Fb
['P5', 'C'] - build an ascending P5 interval starting from C
['P4', 'E#'] - build an ascending P4 interval starting from E#

method IntervalIdentification

The function 'intervalIdentification' must take an array of strings as input and return a string.
An array contains three or two elements.
The first element is the first note in the interval, the second element is the last note in the interval, the third indicates whether an interval is ascending or descending.
If there is no third element in an array, the interval is considered ascending by default.
The function should return a string - name of the interval.
Only the following intervals are allowed in a return string:
m2 M2 m3 M3 P4 P5 m6 M6 m7 M7 P8
If the interval does not fit a description, an exception should be thrown: "Cannot identify the interval".

['C', 'D'] - find an ascending interval between C and D
['C#', 'Fb'] - find an ascending interval between C# and Fb
['A', 'G#', 'asc'] - find an ascending interval between A and G#
