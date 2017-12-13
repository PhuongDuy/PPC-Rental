Feature: US03_ViewDetails
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Background: 
Given the following projects
| Property Name                    | Images | Street Name                        | Price     | Property Type | District  | Ward        | Street       | City        | Packing Place | Bed Room | Bathroom |
| PIS Serviced Apartment – Style 3 | 1.jpg  | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30000 USD | Office        | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | Hồ Chí Minh | 1             | 2        | 4        |


Scenario: Hien thi chi tiet du an thanh cong  
	When User click "ID_Project"
	Then Hien thi thong tin chi tiet du an
| Property Name                    | Images | Street Name                        | Price     | Property Type | District  | Ward        | Street       | City        | Packing Place | Bed Room | Bathroom |
| PIS Serviced Apartment – Style 3 | 1.jpg  | Đường Nội Bộ TT Chúc Sơn Chương Mỹ | 30000 USD | Office        | Chương Mỹ | TT Chúc Sơn | Đường Nội Bộ | Hồ Chí Minh | 1             | 2        | 4        |

