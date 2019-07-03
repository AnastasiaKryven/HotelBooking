update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\А1.jpg', Single_Blob) MyImage)
where RoomId=6

update Rooms set[ImageData]=(select MyImage.*
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\А2.jpg', Single_Blob) MyImage)
where RoomId=7

update Rooms set[ImageData]=(select MyImage.*
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\А3.jpg', Single_Blob) MyImage)
where RoomId=8
update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Б1.jpg', Single_Blob) MyImage)
where RoomId=9

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Б2.jpg', Single_Blob) MyImage)
where RoomId=10

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Б3.jpg', Single_Blob) MyImage)
where RoomId=11

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\В1.jpg', Single_Blob) MyImage)
where RoomId=12

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\В2.jpg', Single_Blob) MyImage)
where RoomId=13

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\В3.jpeg', Single_Blob) MyImage)
where RoomId=14

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Люкс1.jpg', Single_Blob) MyImage)
where RoomId=15

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Люкс2.jpg', Single_Blob) MyImage)
where RoomId=16

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\Solution\Hotel.WebUI\Content\Images\Люкс3.jpg', Single_Blob) MyImage)
where RoomId=17


