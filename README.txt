Worker - ContractorId jest niepotrzebne w cholerę (kontrahent zatrudnia Userów a nie Workerów)✓
User - Worker LastEditorem nie musi być worker, użytkownik sam powinien zmienić swoje dane✓
AddressSet - LastEditor może być nullem, bo adres będzie dodawany przez użytkownika zazwyczaj✓
BoughtPackages - tabela uzupełniana automatycznie, LastEditor może być nullem✓
ContactSet - to samo co AddressSet✓
ContractorSet - kontrahent powinien móc samemu wyedytować swoje dane, LastEditor może być nullem✓
ContractSet - LastEditor nullable✓
ExReportsSets - LastEditor nullable✓
Incomes - LastEditor nullable✓
ListOfItems - LastEditor nullable✓
ListOfUsers - scalić z ExReportsSets, jako że obie mają służyć do tego samego✓
RoomSets - LastEditor nullable✓
VindicationSets - LastEditor nullable✓