;;; Display a greeting depending on the hour

;;; if its the morning print "Good Morning" using the WriteLine function on the Console object
(if (< (Hour (Now DateTime)) 12) (writeline console  "Good Morning") 
	;;; if its the afternoon (uses the "prl" function that is built in):
	(< (Hour (Now DateTime)) 18) (prl  "Good Afternoon") 
	;;; otherwise its evening:
	(prl "Good Evening"))