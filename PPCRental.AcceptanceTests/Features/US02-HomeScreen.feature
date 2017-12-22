Feature: US02 - Home Screen
	As a potential customer
	I want to see the prject with the best price
	So that I can save money 

Background:
	Given show the new project
	| Image                   | NameProperty                                 | Content                                                                                                                    | Address                            | Price   |
	| PIS3611.jpg             | PIS Serviced Apartment- Style 3              | The well equipped kitchen is opened on a cozy living room and a dining area with table and chairs.. Behind the...          | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30.000  |
	| PIS_7389-Edit-stamp.jpg | Vinhomes Central Park L2 – Duong’s Apartment | Vinhomes Central Park is a new development that is in the heart of everything that Ho Chi Minh has to offer. Located in... | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 110.000 |
	| PIS_7319-Edit-stamp.jpg | Saigon Pearl Ruby Block                      | – Located on Nguyen Huu Canh Street, this nice apartment has all amenities like swimming pool, sauna,...                   | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30.000  |
	| PIS_6706-Edit-stamp.jpg | Nguyen Dinh Chinh – Duplex with Balcony      | The Nguyen Dinh Chinh is a lovely option for the renter seeking home-comfort away from the noise of the city...            | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 200.000 |

	
	And show the hot project
	| Image                   | NameProperty                                 | Area  | BedRoon | BathRoom | Packing Place | Address                            | Price   |
	| PIS3611.jpg             | PIS Serviced Apartment- Style 3              | 130m2 | 2       | 4        | 1             | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30.000  |
	| PIS_7389-Edit-stamp.jpg | Vinhomes Central Park L2 – Duong’s Apartment | 150m2 | 4       | 2        | 1             | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 110.000 |
	| PIS_7319-Edit-stamp.jpg | Saigon Pearl Ruby Block                      | 130m2 | 3       | 3        | 1             | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30.000  |
	| PIS_6706-Edit-stamp.jpg | Nguyen Dinh Chinh – Duplex with Balcony      | 120m2 | 3       | 2        | 2             | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 200.000 |


Scenario: Show Homepage 
	When User enter the main page
	Then the home screen should show the interface of the website	
	| Title                                        |
	| PIS Serviced Apartment- Style 3              |
	| Vinhomes Central Park L2 – Duong’s Apartment |
	| Saigon Pearl Ruby Block                      |
	| Nguyen Dinh Chinh – Duplex with Balcony      |
