Feature: US02-ViewListProject
	Toi la user
	Toi muon xem danh sach cac du an duoc giao dich

Background: following theo buoc tren
Given the following users
		| Email             | Password | FullName        |
		| tanninh@gmail.com | 123456   | Nguyễn Tấn Ninh |
And the following projects
		| PropertyName | Content     | Price | Area   | BedRoom | PackingPlace | Status_Name |
		| Dream House  | Near quan 1 | 5000  | 1200m2 | 6       | 2            | Chưa duyệt  |
		
@automation
Scenario: View List Projects
	Given Toi dang o trang chu
	And Toi di den dang nhap
	When Toi dang nhap email 'tanninh@gmail.com' va '123456'
	Then Toi se thay duoc danh sach cac du an cua toi
	| PropertyName |
	| Dream House  |
