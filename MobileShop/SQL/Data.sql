insert into Customer values('Dejan', 'Besic', 'Zeleznicka 15', 'admin@gmail.com', 'pass', 0, 1, 1);
insert into Customer values('Srdjan', 'Besic', 'Zeleznicka 15', 'pwi1@gmail.com', 'pass', 0, 1, 0);

insert into Additional values ('Citac otisaka prstiju, Quick Charge 3.0');
insert into Additional values ('Dual kamera (16+2 MP), Citac otisaka prstiju');
insert into Additional values ('TurboPower Charger');
insert into Additional values ('CitaC otisaka prstiju, IP68 vodootporan');

insert into Battery values('1821 mAh');
insert into Battery values('3300 mAh');
insert into battery values('3230 mAh');
insert into battery values('3500 mAh');
insert into battery values('2691 mAh');
insert into battery values('3000 mAh');
insert into battery values('1960 mAh');
insert into battery values('4000 mAh');
insert into battery values('2400 mAh');
insert into battery values('1810 mAh');
insert into battery values('3600 mAh');
insert into battery values('3200 mAh');

insert into CAMERA values('13 MP', 'dual (normalna + sirokougaona), autofokus, LED blic, f/1.8', '5 MP', 'sirokougaona, f/2.2', '2160p@30fps'); 
insert into CAMERA values('12 MP', ' dual pixel, autofokus, LED blic, OIS, f/1.7', '8 MP', 'autofokus, f/1.7', '4k video'); 
insert into CAMERA values('12 MP', 'dodatna kamera 20 MP, autofokus, OIS, LED blic, f/2.2', '8 MP', 'f/1.9', '2160p@30fps'); 
insert into CAMERA values('16 MP', 'f/1.7, autofokus, LED blic, geo-tagging', '16 MP', 'dodatna prednja kamera od 8 MP, f/1.9', ' Da, 1080p@30fps'); 
insert into CAMERA values('13 MP', 'f/1.9, autofokus, LED blic', ' 8 MP', 'f/1.9, prednji blic', 'Da, FullHD'); 
insert into CAMERA values('12 MP', 'dodatna kamera od 8 MP, f/2.0, PDAF autofokus, LED blic', '16 MP', 'f/2.0', 'Da, 2160p@30fps'); 
insert into CAMERA values('13 MP', 'f/2.0, autofokus, LED blic', '5 MP', 'LED blic', 'Da, 1080p@30fps'); 

insert into Characteristics values('Nano SIM', 1, '154.4 x 72.2 x 8.95 mm', '174 g');
insert into Characteristics values('Nano SIM', 1, '152.4 x 73 x 7.8 mm', '150 g');
insert into Characteristics values('Nano SIM', 1, '151.1 x 70.73 x 8.27 mm', '/');
insert into Characteristics values('Nano SIM', 0, '149.2 x 70.6 x 8.4 mm', '172 g');
insert into Characteristics values('Nano SIM', 0, '152.4 x 73 x 7.8 mm', '150 g');
insert into Characteristics values('Nano SIM', 0, '143.2 x 70.3 x 8.2 mm', '142 g');
insert into Characteristics values('Nano SIM', 0, '153.9 x 75.9 x 7.9 mm', '169 g');
insert into Characteristics values('Nano SIM', 0, '153.2 x 71.9 x 7.9 mm', '162 g');

insert into Communication values('GPRS, EDGE, HSDPA, HSUPA, HSPA+, DC-HSPA+, LTE',	 '850/900/1800/1900 MHz',
								'850/900/1700/1800/1900/2100 MHz',					 'FDD 700/800/850/900/1700/1800/1900/2100/2600 MHz, TDD 1900/2300/2500/2600 MHz', 
								'Da, Lightning',									 'Da, 802.11 b/g/n/ac, dualband', 
								'Da, v4.2', 1, 1,									 'SMS,MMS, Email, Push Mail, IM');


insert into Communication values('GPRS, EDGE, HSDPA, HSUPA, HSPA+, DC-HSPA+, LTE',	 '850/900/1800/1900 MHz',
								'850/900/1700/1800/1900/2100 MHz',					 'FDD 700/800/850/900/1700/1800/2100/2600 MHz, TDD 2300/2600/3500/5200 MHz', 
								'Da, Type-C',										 'Da, 802.11 b/g/n/ac, dualband', 
								'Da, v5.0', 1, 1,									 'SMS, MMS, Email, Push Mail, IM');

insert into Communication values('GPRS, EDGE, HSDPA, HSUPA, HSPA+, DC-HSPA+, LTE',	 '850/900/1800/1900 MHz',
								'850/900/1700/1800/1900/2100 MHz',					 'FDD 700/800/850/900/1800/1900/2100/2600 MHz, TDD 1900/2300/2500/2600 MHz', 
								'Da, Type-C',										 'Da, 802.11 b/g/n/ac, dualband', 
								'Da, v4.2', 1, 1,									 'SMS, MMS, Email, Push Mail, IM');

insert into Communication values('GPRS, EDGE, HSDPA, HSUPA, HSPA+, DC-HSPA+, LTE',	 '850/900/1800/1900 MHz',
								'850/900/1700/1800/1900/2100 MHz',					 'FDD 700/800/850/900/1800/1900/2100/2600 MHz, TDD 1900/2300/2500/2600 MHz', 
								'Da, Type-C',										 'Da, 802.11 b/g/n/ac, dualband', 
								'Da, microUSB', 1, 1,									 'SMS, MMS, Email, Push Mail, IM');


insert into memory values ('do 16 GB', 'microSD podrska (do 256 GB)');
insert into memory values ('do 64 GB', 'microSD podrska (do 256 GB)');
insert into memory values ('do 32 GB', 'microSD podrska (do 256 GB)');
insert into memory values ('do 16 GB', 'microSD podrska (do 128 GB)');
insert into memory values ('do 64 GB', 'Ne');
insert into memory values ('do 64 GB', 'microSD podrška (do 2 TB)');

insert into PackageContent values ('punjac, garancija, uputstvo, USB kabl, slusalice');
insert into PackageContent values ('punjac, garancija, uputstvo, USB kabl, slusalice, 3.5mm konverter');
insert into PackageContent values ('punjac, garancija, uputstvo');
insert into PackageContent values ('punjac, slusalice, garancija, uputstvo');

insert into PhonePlatform values('iOS 10', 'Quad-core 2.23 GHz', '2 GB');
insert into PhonePlatform values('Android 8.0', '4 GB', 'Octa-core (Quad-core 2.8 GHz & Quad-core 1.7 GHz)');
insert into PhonePlatform values('Android 7.1', '4 GB', 'Octa-core 2.45 GHz');
insert into PhonePlatform values('Android 7.0', '2 GB', 'Quad-core 1.4 GHz');
insert into PhonePlatform values('Android 7.1', '4 GB', 'Octa-core 2.2 GHz');
insert into PhonePlatform values('Android 7.1', '4 GB', 'Octa-core (Dual-core 2.2 GHz & Hexa-core 1.6 GHz)');

insert into screen values ('4.7"','1334x750','Retina', 1);
insert into screen values ('6.1"','3120x1440','FullVision IPS', 1);
insert into screen values ('5.5"','2560x1440','Super LCD 5, Corning Gorilla Glass 5', 1);
insert into screen values ('5.0"','1280x720','PLS TFT LCD', 1);
insert into screen values ('5.5"','1920x1080','Super AMOLED', 1);
insert into screen values ('5.6"','2220x1080','Super AMOLED', 1);
insert into screen values ('5.5"','2160x1080','IPS', 1);

insert into sound values(1, 1, 1);
insert into sound values(1, 0, 0);
insert into sound values(0, 1, 0);
insert into sound values(0, 0, 1);
insert into sound values(1, 1, 0);
insert into sound values(0, 1, 1);
insert into sound values(1, 0, 1);
insert into sound values(1, 1, 1);
insert into sound values(0, 0, 0);