;;; Lists all the items from an RSS Feed

(reference "System.Xml")

(= news (new System.Xml.XmlDocument))
(call load news "http://www.theregister.co.uk/headlines.rss")
(foreach node (selectnodes news "/rss/channel/item/title") 
	(prl (innertext node)))
