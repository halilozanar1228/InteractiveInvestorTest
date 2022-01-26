Feature: Replicating how a customer would navigate to Trading Accoung

Scenario: When user go to ii web page, navigate to Trading Account page
	Given Open a browser and go to  webpage
	And Click on the “Services” dropdown 
	When Click on the link <ServicesLinks> link
	Then Should see expected <ServicesLinks>
	Examples:
| ServicesLinks      |
| Trading Account    |
| Stock And Shares   |