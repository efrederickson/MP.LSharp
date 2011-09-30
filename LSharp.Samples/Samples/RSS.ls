;;; An RSS Reader in 4 lines of code

(reference "System.Xml") 
(= news (new "System.Xml.XmlDocument")) ;;; Create a new XmlDocument
(call load news "http://www.toothandnail.com/rss/news/") ;;; load some headtitles
(prl (map (fn (x) (innertext x)) (selectnodes news  "/rss/channel/item/title"))) ;;; print them to the console