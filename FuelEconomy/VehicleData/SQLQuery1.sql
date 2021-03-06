﻿INSERT INTO [dbo].[Make] (Label)
VALUES ('Acura'),
('Alfa Romeo'),
('AM General'),
('American Motors Corporation'),
('ASC Incorporated'),
('Aston Martin'),
('Audi'),
('Aurora Cars Ltd'),
('Autokraft Limited'),
('Avanti Motor Corporation'),
('Azure Dynamics'),
('Bentley'),
('Bertone'),
('Bill Dovell Motor Car Company'),
('Bitter Gmbh and Co. Kg'),
('BMW'),
('BMW Alpina'),
('Bugatti'),
('Buick'),
('BYD'),
('Cadillac'),
('CCC Engineering'),
('Chevrolet'),
('Chrysler'),
('CODA Automotive'),
('Consulier Industries Inc'),
('CX Automotive'),
('Dabryan Coach Builders Inc'),
('Dacia'),
('Daewoo'),
('Daihatsu'),
('Dodge'),
('E. P. Dutton, Inc.'),
('Eagle'),
('Environmental Rsch and Devp Corp'),
('Evans Automobiles'),
('Excalibur Autos'),
('Federal Coach'),
('Ferrari'),
('Fiat'),
('Fisker'),
('Ford'),
('General Motors'),
('Genesis'),
('Geo'),
('GMC'),
('Goldacre'),
('Grumman Allied Industries'),
('Grumman Olson'),
('Honda'),
('Hummer'),
('Hyundai'),
('Import Foreign Auto Sales Inc'),
('Import Trade Services'),
('Infiniti'),
('Isis Imports Ltd'),
('Isuzu'),
('J.K. Motors'),
('Jaguar'),
('JBA Motorcars, Inc.'),
('Jeep'),
('Kenyon Corporation Of America'),
('Kia'),
('Laforza Automobile Inc'),
('Lambda Control Systems'),
('Lamborghini'),
('Land Rover'),
('Lexus'),
('Lincoln'),
('London Coach Co Inc'),
('London Taxi'),
('Lotus'),
('Mahindra'),
('Maserati'),
('Maybach'),
('Mazda'),
('Mcevoy Motors'),
('McLaren Automotive'),
('Mercedes-Benz'),
('Mercury'),
('Merkur'),
('MINI'),
('Mitsubishi'),
('Mobility Ventures LLC'),
('Morgan'),
('Nissan'),
('Oldsmobile'),
('Pagani'),
('Panos'),
('Panoz Auto-Development'),
('Panther Car Company Limited'),
('PAS Inc - GMC'),
('PAS, Inc'),
('Peugeot'),
('Pininfarina'),
('Plymouth'),
('Pontiac'),
('Porsche'),
('Quantum Technologies'),
('Qvale'),
('Ram'),
('Red Shift Ltd.'),
('Renault'),
('Rolls-Royce'),
('Roush Performance'),
('Ruf Automobile Gmbh'),
('S and S Coach Company  E.p. Dutton'),
('Saab'),
('Saleen'),
('Saleen Performance'),
('Saturn'),
('Scion'),
('Shelby'),
('smart'),
('Spyker'),
('SRT'),
('Sterling'),
('Subaru'),
('Superior Coaches Div E.p. Dutton'),
('Suzuki'),
('Tecstar, LP'),
('Tesla'),
('Texas Coach Company'),
('Toyota'),
('TVR Engineering Ltd'),
('Vector'),
('Vixen Motor Company'),
('Volga Associated Automobile'),
('Volkswagen'),
('Volvo'),
('VPG'),
('Wallace Environmental'),
('Yugo')

INSERT INTO [dbo].[Transmission] (Label)
VALUES ('Auto(AM-S6)'),
('Automatic (A1)'),
('Automatic (AM5)'),
('Automatic (AM6)'),
('Automatic (AM7)'),
('Automatic (AM8)'),
('Automatic (AM-S6)'),
('Automatic (AM-S7)'),
('Automatic (AM-S8)'),
('Automatic (AM-S9)'),
('Automatic (AV-S10)'),
('Automatic (AV-S6)'),
('Automatic (AV-S7)'),
('Automatic (AV-S8)'),
('Automatic (L3)'),
('Automatic (L4)'),
('Automatic (S10)'),
('Automatic (S4)'),
('Automatic (S5)'),
('Automatic (S6)'),
('Automatic (S7)'),
('Automatic (S8)'),
('Automatic (S9)'),
('Automatic (variable gear ratios)'),
('Automatic 3-spd'),
('Automatic 4-spd'),
('Automatic 5-spd'),
('Automatic 6-spd'),
('Automatic 7-spd'),
('Automatic 8-spd'),
('Automatic 9-spd'),
('Manual 3-spd'),
('Manual 4-spd'),
('Manual 4-spd Doubled'),
('Manual 5-spd'),
('Manual 6-spd'),
('Manual 7-spd')



GO

INSERT INTO [dbo].[VehicleClass] (Label)
VALUES ('Compact Cars'),
('Large Cars'),
('Midsize Cars'),
('Midsize Station Wagons'),
('Midsize-Large Station Wagons'),
('Minicompact Cars'),
('Minivan - 2WD'),
('Minivan - 4WD'),
('Small Pickup Trucks'),
('Small Pickup Trucks 2WD'),
('Small Pickup Trucks 4WD'),
('Small Sport Utility Vehicle 2WD'),
('Small Sport Utility Vehicle 4WD'),
('Small Station Wagons'),
('Special Purpose Vehicle'),
('Special Purpose Vehicle 2WD'),
('Special Purpose Vehicle 4WD'),
('Special Purpose Vehicles'),
('Special Purpose Vehicles/2wd'),
('Special Purpose Vehicles/4wd'),
('Sport Utility Vehicle - 2WD'),
('Sport Utility Vehicle - 4WD'),
('Standard Pickup Trucks'),
('Standard Pickup Trucks 2WD'),
('Standard Pickup Trucks 4WD'),
('Standard Pickup Trucks/2wd'),
('Standard Sport Utility Vehicle 2WD'),
('Standard Sport Utility Vehicle 4WD'),
('Subcompact Cars'),
('Two Seaters'),
('Vans'),
('Vans Passenger'),
('Vans, Cargo Type'),
('Vans, Passenger Type')

GO

INSERT INTO [dbo].[Drive] (Label)
VALUES ('2-Wheel Drive'),
('4-Wheel Drive'),
('4-Wheel or All-Wheel Drive'),
('All-Wheel Drive'),
('Front-Wheel Drive'),
('Part-time 4-Wheel Drive'),
('Rear-Wheel Drive'),
('NA')

GO

INSERT INTO [dbo].[FuelType] (Label)
VALUES ('CNG'),
('Diesel'),
('Electricity'),
('Gasoline or E85'),
('Gasoline or natural gas'),
('Gasoline or propane'),
('Midgrade'),
('Premium'),
('Premium and Electricity'),
('Premium Gas or Electricity'),
('Premium or E85'),
('Regular'),
('Regular Gas and Electricity'),
('Regular Gas or Electricity')



GO

INSERT INTO [dbo].[Cylinders] (Label)
VALUES ('2'),
('3'),
('4'),
('5'),
('6'),
('8'),
('10'),
('12'),
('16'),
('NA')

