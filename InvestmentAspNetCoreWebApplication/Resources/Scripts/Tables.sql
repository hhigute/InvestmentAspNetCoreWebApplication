create database DbInvestment; 

use DbInvestment;

create table dbo.IofRference(
	NrDay int not null,
	PercentFee decimal(5,2) not null,
	constraint PK_IofRference primary key (NrDay)
);

create table dbo.IRReference(
	StartDay int not null,
	FinishDay int not null,
	PercentFee decimal(5,2) not null,
	constraint PK_IRReference primary key (StartDay,FinishDay)
);

create table dbo.RiskLevel(
	Id int not null primary key,
	Description nvarchar(20) not null
);
alter table RiskLevel add constraint UQ_RiskLevel unique (Description); 



create table dbo.Customer(
	Document nvarchar(19) not null primary key,
	Name nvarchar(50) not null,
	Phone nvarchar(15) not null
);

create table dbo.Bank(
	Code nvarchar(3) not null primary key,
	Name nvarchar(50) not null,
	ContactName nvarchar(50) not null,
	ContactPhone nvarchar(15) not null
);

create table dbo.CustomerBank(
	CustomerDoc nvarchar(19) not null,
	CodeBank nvarchar(3) not null,
	BranchCode nvarchar(5) not null,
	AccountNumber nvarchar(15) not null
);
alter table CustomerBank add constraint PK_CustomerBank primary key (CustomerDoc,CodeBank);
alter table CustomerBank add constraint FK_CustomerBank_Customer foreign key (CustomerDoc) references Customer(Document);
alter table CustomerBank add constraint FK_CustomerBank_Bank foreign key (CodeBank) references Bank(Code);


create table dbo.ProductBank (
	Id int not null IDENTITY(1,1),
	CodeBank nvarchar(3) not null, 
	Description nvarchar(100) not null,
	AdministrationFee decimal(4,2) not null,
	DueDate date,
	LiquidityDay int not null,
	IdRiskLevel int not null,
	IsActive bit not null,
	CreationDate datetime not null,
	UserCreation nvarchar(30) not null,
	UpdateDate dateTime,
	UserUpdate nvarchar(30) 
);
alter table ProductBank add constraint PK_ProductBank primary key (codeBank,description);
alter table ProductBank add constraint FK_ProductBank_Bank foreign key (CodeBank) references Bank(Code);
alter table ProductBank add constraint FK_ProductBank_RiskLevel foreign key (IdRiskLevel) references RiskLevel(Id);
create index IX01_ProductBank on ProductBank(Id);


