SET IDENTITY_INSERT [dbo].[PrepaidCustomer] ON
INSERT INTO [dbo].[PrepaidCustomer] ([Id], [Name], [RegistereddDate]) VALUES (1, N'Greg Thompson', N'2020-12-08 00:00:00')
INSERT INTO [dbo].[PrepaidCustomer] ([Id], [Name], [RegistereddDate]) VALUES (2, N'Philip Wilkinson', N'2020-12-03 00:00:00')
SET IDENTITY_INSERT [dbo].[PrepaidCustomer] OFF
SET IDENTITY_INSERT [dbo].[MobileAccount] ON
INSERT INTO [dbo].[MobileAccount] ([Id], [Number], [Balance], [PrepaidCustomerId]) VALUES (1, N'02188897654', CAST(100.00 AS Decimal(18, 2)), 1)
INSERT INTO [dbo].[MobileAccount] ([Id], [Number], [Balance], [PrepaidCustomerId]) VALUES (2, N'02288890765', CAST(200.00 AS Decimal(18, 2)), 2)
SET IDENTITY_INSERT [dbo].[MobileAccount] OFF
SET IDENTITY_INSERT [dbo].[TopUpChannel] ON
INSERT INTO [dbo].[TopUpChannel] ([Id], [Name], [Description]) VALUES (1, N'Web', N'Top up via website')
INSERT INTO [dbo].[TopUpChannel] ([Id], [Name], [Description]) VALUES (2, N'Mobile App', N'Top up via mobile app')
INSERT INTO [dbo].[TopUpChannel] ([Id], [Name], [Description]) VALUES (3, N'Card', N'Top up via prepaid card')
SET IDENTITY_INSERT [dbo].[TopUpChannel] OFF
SET IDENTITY_INSERT [dbo].[TopUp] ON
INSERT INTO [dbo].[TopUp] ([Id], [MobileAccountId], [TopUpChannelId], [TopUpAmount]) VALUES (1, 2, 2, CAST(40.00 AS Decimal(18, 2)))
INSERT INTO [dbo].[TopUp] ([Id], [MobileAccountId], [TopUpChannelId], [TopUpAmount]) VALUES (2, 2, 1, CAST(70.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[TopUp] OFF
