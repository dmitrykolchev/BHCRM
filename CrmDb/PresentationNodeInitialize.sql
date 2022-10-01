declare @xml xml = N'<ArrayOfPresentationNode>
  <PresentationNode Id="1630" State="1" FileAs="Главное окно" Key="MainWindow" OrdinalPosition="10" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:00.470" CreatedBy="2" Modified="2015-01-29T14:11:06.763" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1631" State="1" FileAs="CRM" Key="CRM" OrdinalPosition="10" ParentId="1630" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADSSURBVDhPYxhwwFhUVPQfyiYPgAwgF4D0MkHNAYPLD94yFM46DMYgNjEAxYDOVWcYbj15D8YgNjGABUqDARMTI5SFyt6yZQuUhQA+Pj5gGsWAfH8Dhv715+FsGIApxgbgBjx584Vhwe7rDJMy7Rn+/f/P0LriDIOkMDeDlBA3cS7oXHWW4d6Ljwzrj90FOx8UDt1rzjH0p9kS54Ln776C6XVH74JpEHj94RuYJsoFKR7aDEv23WB4/+UnmC/Iw86Q4KoFZuNzAcUJifKkPMCAgQEAwlrG0GFM4kEAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAGGSURBVFhHYxgFo2CgASOUZmhoaPgPZdIFAO2D2w0GIAfQCyB7lglKDxgYdQBeB/z5+49hyf7bDIkTDoIxiA0SoyZggdJYwbKDdxjWHL0P5TEwrDpyj+Hf//8McU5qUBEI2LJlC5SFH/j4+EBZCIDXAbvPP4WyEAAkhu4AbAYTCwZ3GnA1lIayEMBZH1OMEoA3CqLsVYCJ7j/DwSvPwXx7HUmGGEcVMBsZUJIG4GCgSkKsIQDKassO3GLYc/4Rg6maOEOunz5YfPKmiwynb71kcDGUY4hyUGNgYYbEINVzwdojdxhWHrwFZu8694jB20wBzv737z9YjpWZkSHSQR0sTkkuwHAAKJ9vP/MQygPygRbO2HoZzoaBnWcfMYTbqzEwMTJSPwRef/wOZUHA1YfvoCwEQFZD1RAA+YiLnYXh288/UBHsAKQGpBYEqB4CEzPtGTafuMdw7s5rhhfvv8HLf1CikxDkYjBSEWXwtVACi4EAJSEAB6MNkoECg6dROgpGwcAABgYAKljPi/sV0jEAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:00.490" CreatedBy="2" Modified="2014-11-26T16:43:00.490" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1632" State="1" FileAs="Контрагенты" Key="Accounts" DefaultViewId="1633" OrdinalPosition="10" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.510" CreatedBy="2" Modified="2015-01-26T00:18:18.573" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1633" State="1" FileAs="Мои контрагенты" Key="MyAccountsView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountGridControl, DykBits.Crm.Dictionaries" Parameter="MyAccounts" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.527" CreatedBy="2" Modified="2014-11-26T16:43:00.527" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1634" State="1" FileAs="Все контрагенты" Key="AccountView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.AccountGridControl, DykBits.Crm.Dictionaries" Parameter="AllAccounts" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.540" CreatedBy="2" Modified="2015-01-26T00:18:36.840" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1635" State="1" FileAs="Покупатели" Key="AccountViewCustomers" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountGridControl, DykBits.Crm.Dictionaries" Parameter="Customers" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.553" CreatedBy="2" Modified="2015-01-26T00:18:51.373" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1636" State="1" FileAs="Поставщики" Key="AccountViewSuppliers" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.AccountGridControl, DykBits.Crm.Dictionaries" Parameter="Suppliers" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.567" CreatedBy="2" Modified="2015-01-26T00:19:03.747" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1637" State="1" FileAs="Площадки" Key="VenueView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.VenueGridControl, DykBits.Crm.Dictionaries" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.580" CreatedBy="2" Modified="2015-01-26T00:19:14.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1638" State="1" FileAs="Участники маркетинговых программ" Key="AccountByMarketingProgramView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.AccountByMarketingProgramViewGridControl, DykBits.Crm.Dictionaries" ParentId="1632" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.593" CreatedBy="2" Modified="2014-11-26T16:43:00.593" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1639" State="1" FileAs="Контакты" Key="Contacts" DefaultViewId="1640" OrdinalPosition="20" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.640" CreatedBy="2" Modified="2015-01-26T00:19:30.053" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1640" State="1" FileAs="Мои контакты" Key="MyContactView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ContactGridControl, DykBits.Crm.Dictionaries" Parameter="MyContacts" ParentId="1639" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.653" CreatedBy="2" Modified="2014-11-26T16:43:00.653" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1641" State="1" FileAs="Все контакты" Key="AllContactView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ContactGridControl, DykBits.Crm.Dictionaries" Parameter="AllContacts" ParentId="1639" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.667" CreatedBy="2" Modified="2015-01-26T00:19:43.107" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1642" State="1" FileAs="Участники маркетинговых программ" Key="ContactByMarketingProgramView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.ContactByMarketingProgramViewGridControl, DykBits.Crm.Dictionaries" ParentId="1639" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.680" CreatedBy="2" Modified="2014-11-26T16:43:00.680" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1643" State="1" FileAs="События" Key="AccountEvents" DefaultViewId="1644" OrdinalPosition="30" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.717" CreatedBy="2" Modified="2014-11-28T20:13:46.970" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1644" State="1" FileAs="Мои события" Key="MyAccountEventView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" Parameter="MyAccountEvents" ParentId="1643" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.730" CreatedBy="2" Modified="2014-11-26T16:43:00.730" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1645" State="1" FileAs="Все события" Key="AccountEventView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" Parameter="AllAccountEvents" ParentId="1643" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.743" CreatedBy="2" Modified="2014-11-26T16:43:00.743" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1646" State="1" FileAs="Календарь" Key="AccountEventScheduleView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountEventSchedulerControl, DykBits.Crm.Dictionaries" Parameter="MyAccountEvents" ParentId="1643" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACdSURBVDhPrZPBDcMgDEWdijHSUThw48A0SGWIrgMS3Bgm2QIkIlNzqNJSFPoufj4Y+JJZtNYFJrhRvcz0AYARGtZass+eUire++oIzg69QClVK2MMpJTVG4sxpnDOqT2Dw7u5U/difW7gnIMY41iE7bGSvftwhB51D4QQ1J75S4RvDEfA25CcM4QQqjd+RugxHKH55UXqMf0bJwE4ABjfDdBC0FGPAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACuSURBVFhH7dTBDcIwDAVQlynYIzvAJcuwQSaAYZILQ2SOdotC0S8hbpBCW6sS9bvE9iWu+hVSu9fgfHHO9ShFPe9533vAuRldIDNkgPPeo0qWzHjO9BestoC1FlVSmnGTd8AYg67ecFF3O6PLHS93CiGgI4oxZu9AZkkI2+sJVVKaaQi5zRf4nxDWEgvh51eOSjNOQ7hKCH8hFsLamVgI59IFJiFEKeprCNUOET0AFzu0d+3bTXgAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:00.757" CreatedBy="2" Modified="2014-11-26T16:43:00.757" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1647" State="1" FileAs="Задачи" Key="ProjectTasks" DefaultViewId="1648" OrdinalPosition="40" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.783" CreatedBy="2" Modified="2014-11-28T20:13:56.570" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1648" State="1" FileAs="Мои задачи" Key="MyTasks" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskGridControl, DykBits.Crm.Dictionaries" Parameter="MyTasks" ParentId="1647" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAD5SURBVDhPnZC/CsIwEIf7TLoquPgI6qSI4AO0zgp1cXdxcBU36VJxEEF9iKKFgi7iH0REJEKpZ++SoEJr1A+OpJf7fQnV4tB1vWUYBoRrQ7Ti2U3NyX7eBAljDDAsS3IPfMA5nBdRDjalwLbtt7Asy7LoXM6KKOdVEBWWhS9TClT8LQguZ1r/EqzqFViWM7T/WXAYdMHJJWDT4edKwa7XphByW7vg5JPgGTn6RpQCr1agG0/jASxKaVgUUxCwK50hSgH4PrjVLEnwduY5vC9QC0Lwj+PNx2FfdJ58JSDCl0TxUfBLiSgnakBVIsrZzsxR1FBc4TxPatoD7Z2TWflCb8YAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAINSURBVFhH7ZbNSxthEMbzn3mRIvQkQunJi4h4ESleRGKC11JEhJ48COKh0JMUpSeDSPy4ePDgJ1GMJWiSNljrVxqnmd1n12eXFye6sSd/MId9Z5/fzGb3kNQrzyGTyYxns1nh0jO0X5748KDQfnniA9u+wHk+3VFeS29U18dFyeVykSeND3T1NKOoQ13qxO02lbV0SYPBAq4BrZQSeNQJvU0QaucCWtDbcEhxyVsphV3Q23AoKeyC3oZDSWEX9DYceio/Pk/I+dcZkUbDu2YX9DYcegrVpS+y29fp1dn8tH9GLuhtONQqV/vbstv/xhu+N9Al18f73jm7oLfhUCv8vajJ4cj78OlrK4vo/I8Fmu+6ODkaDi/NfkLDh13Q23BIudhcluOJQe9J41S+zYfD9Z77eh0dH3ZBb8OhPztbkQGNq0uoxe/hvR8MdctduYTOA+yC3oZDOvAo0x8ucfJxRO5vb6Req8rhh3f+eXOJy+1NjIzCLuhtOKTUf5YjH9npdNpbJLiuLMx597lgF/Q2HAq4KRbkYLgnHBpUcWoMd7hhF/Q2HGKuCzuyN/g2HF4Y7Y18Ey7YBb0Nh+L83sp771wX0V/Fgl3Q23DIxa/lBamtfsfV47ALehsOJYVd0NtwKCnsgt6GQ+0s6G1c4XYU9DbNv9GnLkGSUif0Nmf5sS7+a5601KVO6F8hUql/wQtk22ZpoGkAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:00.797" CreatedBy="2" Modified="2015-04-06T10:04:39.573" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1649" State="1" FileAs="Задачи моих проектов" Key="MyProjectTasks" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskGridControl, DykBits.Crm.Dictionaries" Parameter="MyProjectTasks" ParentId="1647" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAD5SURBVDhPnZC/CsIwEIf7TLoquPgI6qSI4AO0zgp1cXdxcBU36VJxEEF9iKKFgi7iH0REJEKpZ++SoEJr1A+OpJf7fQnV4tB1vWUYBoRrQ7Ti2U3NyX7eBAljDDAsS3IPfMA5nBdRDjalwLbtt7Asy7LoXM6KKOdVEBWWhS9TClT8LQguZ1r/EqzqFViWM7T/WXAYdMHJJWDT4edKwa7XphByW7vg5JPgGTn6RpQCr1agG0/jASxKaVgUUxCwK50hSgH4PrjVLEnwduY5vC9QC0Lwj+PNx2FfdJ58JSDCl0TxUfBLiSgnakBVIsrZzsxR1FBc4TxPatoD7Z2TWflCb8YAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAINSURBVFhH7ZbNSxthEMbzn3mRIvQkQunJi4h4ESleRGKC11JEhJ48COKh0JMUpSeDSPy4ePDgJ1GMJWiSNljrVxqnmd1n12eXFye6sSd/MId9Z5/fzGb3kNQrzyGTyYxns1nh0jO0X5748KDQfnniA9u+wHk+3VFeS29U18dFyeVykSeND3T1NKOoQ13qxO02lbV0SYPBAq4BrZQSeNQJvU0QaucCWtDbcEhxyVsphV3Q23AoKeyC3oZDSWEX9DYceio/Pk/I+dcZkUbDu2YX9DYcegrVpS+y29fp1dn8tH9GLuhtONQqV/vbstv/xhu+N9Al18f73jm7oLfhUCv8vajJ4cj78OlrK4vo/I8Fmu+6ODkaDi/NfkLDh13Q23BIudhcluOJQe9J41S+zYfD9Z77eh0dH3ZBb8OhPztbkQGNq0uoxe/hvR8MdctduYTOA+yC3oZDOvAo0x8ucfJxRO5vb6Req8rhh3f+eXOJy+1NjIzCLuhtOKTUf5YjH9npdNpbJLiuLMx597lgF/Q2HAq4KRbkYLgnHBpUcWoMd7hhF/Q2HGKuCzuyN/g2HF4Y7Y18Ey7YBb0Nh+L83sp771wX0V/Fgl3Q23DIxa/lBamtfsfV47ALehsOJYVd0NtwKCnsgt6GQ+0s6G1c4XYU9DbNv9GnLkGSUif0Nmf5sS7+a5601KVO6F8hUql/wQtk22ZpoGkAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:00.810" CreatedBy="2" Modified="2015-04-06T10:05:22.240" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1650" State="1" FileAs="Все задачи" Key="AllTasks" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskGridControl, DykBits.Crm.Dictionaries" Parameter="AllTasks" ParentId="1647" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAD5SURBVDhPnZC/CsIwEIf7TLoquPgI6qSI4AO0zgp1cXdxcBU36VJxEEF9iKKFgi7iH0REJEKpZ++SoEJr1A+OpJf7fQnV4tB1vWUYBoRrQ7Ti2U3NyX7eBAljDDAsS3IPfMA5nBdRDjalwLbtt7Asy7LoXM6KKOdVEBWWhS9TClT8LQguZ1r/EqzqFViWM7T/WXAYdMHJJWDT4edKwa7XphByW7vg5JPgGTn6RpQCr1agG0/jASxKaVgUUxCwK50hSgH4PrjVLEnwduY5vC9QC0Lwj+PNx2FfdJ58JSDCl0TxUfBLiSgnakBVIsrZzsxR1FBc4TxPatoD7Z2TWflCb8YAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAINSURBVFhH7ZbNSxthEMbzn3mRIvQkQunJi4h4ESleRGKC11JEhJ48COKh0JMUpSeDSPy4ePDgJ1GMJWiSNljrVxqnmd1n12eXFye6sSd/MId9Z5/fzGb3kNQrzyGTyYxns1nh0jO0X5748KDQfnniA9u+wHk+3VFeS29U18dFyeVykSeND3T1NKOoQ13qxO02lbV0SYPBAq4BrZQSeNQJvU0QaucCWtDbcEhxyVsphV3Q23AoKeyC3oZDSWEX9DYceio/Pk/I+dcZkUbDu2YX9DYcegrVpS+y29fp1dn8tH9GLuhtONQqV/vbstv/xhu+N9Al18f73jm7oLfhUCv8vajJ4cj78OlrK4vo/I8Fmu+6ODkaDi/NfkLDh13Q23BIudhcluOJQe9J41S+zYfD9Z77eh0dH3ZBb8OhPztbkQGNq0uoxe/hvR8MdctduYTOA+yC3oZDOvAo0x8ucfJxRO5vb6Req8rhh3f+eXOJy+1NjIzCLuhtOKTUf5YjH9npdNpbJLiuLMx597lgF/Q2HAq4KRbkYLgnHBpUcWoMd7hhF/Q2HGKuCzuyN/g2HF4Y7Y18Ey7YBb0Nh+L83sp771wX0V/Fgl3Q23DIxa/lBamtfsfV47ALehsOJYVd0NtwKCnsgt6GQ+0s6G1c4XYU9DbNv9GnLkGSUif0Nmf5sS7+a5601KVO6F8hUql/wQtk22ZpoGkAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:00.823" CreatedBy="2" Modified="2015-04-06T10:05:30.367" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1651" State="1" FileAs="Отчет по статусам задач" Key="ProjectTaskStatusReport" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskStatusReportControl, DykBits.Crm.Dictionaries" ParentId="1647" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.837" CreatedBy="2" Modified="2015-04-06T10:02:08.110" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1652" State="1" FileAs="Заказы покупателей" Key="ServiceRequests" DefaultViewId="1653" OrdinalPosition="50" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.913" CreatedBy="2" Modified="2015-03-25T15:03:16.637" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1653" State="1" FileAs="Мои заказы покупателей" Key="MyServiceRequests" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestGridControl, DykBits.Crm.Dictionaries" Parameter="MyServiceRequests" ParentId="1652" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.927" CreatedBy="2" Modified="2015-03-16T03:11:44.577" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1654" State="1" FileAs="Все заказы покупателей" Key="AllServiceRequests" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestGridControl, DykBits.Crm.Dictionaries" Parameter="AllServiceRequests" ParentId="1652" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.940" CreatedBy="2" Modified="2015-03-16T03:12:08.133" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1655" State="1" FileAs="Проекты" Key="Projects" DefaultViewId="1656" OrdinalPosition="60" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:00.967" CreatedBy="2" Modified="2014-11-28T20:14:08.350" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1656" State="1" FileAs="Мои проекты" Key="MyProjects" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectGridControl, DykBits.Crm.Dictionaries" Parameter="MyProjects" ParentId="1655" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:00.980" CreatedBy="2" Modified="2014-11-26T16:43:00.980" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1657" State="1" FileAs="Все проекты" Key="AllProjects" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProjectGridControl, DykBits.Crm.Dictionaries" Parameter="AllProjects" ParentId="1655" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01" CreatedBy="2" Modified="2014-11-26T16:43:01" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1658" State="1" FileAs="Сметы" Key="Estimates" DefaultViewId="1659" OrdinalPosition="70" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:01.027" CreatedBy="2" Modified="2014-11-28T20:14:13.320" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1659" State="1" FileAs="Мои сметы" Key="MyEstimates" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.EstimatesDocumentGridControl, DykBits.Crm.Dictionaries" Parameter="MyEstimates" ParentId="1658" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.040" CreatedBy="2" Modified="2014-11-26T16:43:01.040" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1660" State="1" FileAs="Все сметы" Key="AllEstimates" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.EstimatesDocumentGridControl, DykBits.Crm.Dictionaries" Parameter="AllEstimates" ParentId="1658" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.067" CreatedBy="2" Modified="2014-11-26T16:43:01.067" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1661" State="1" FileAs="Шаблоны смет" Key="EstimatesTemplateView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.EstimatesTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1658" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.080" CreatedBy="2" Modified="2014-11-26T16:43:01.080" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1662" State="1" FileAs="Шаблоны проектов" Key="ProjectTemplateView" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.ProjectTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.107" CreatedBy="2" Modified="2014-11-28T20:14:25.863" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1663" State="1" FileAs="Собственные организации" Key="OrganizationView" OrdinalPosition="90" ViewControlTypeName="DykBits.Crm.UI.OrganizationGridControl, DykBits.Crm.Dictionaries" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.127" CreatedBy="2" Modified="2014-11-28T20:14:34.067" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1664" State="1" FileAs="Сотрудники" Key="EmployeeView" OrdinalPosition="100" ViewControlTypeName="DykBits.Crm.UI.EmployeeGridControl, DykBits.Crm.Dictionaries" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.140" CreatedBy="2" Modified="2014-11-28T20:14:43.510" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1665" State="1" FileAs="Справочники" Key="CRMDictionaries" OrdinalPosition="110" ParentId="1631" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.153" CreatedBy="2" Modified="2014-11-28T20:15:12.993" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1666" State="1" FileAs="Источники" Key="LeadSourceView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.LeadSourceGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.167" CreatedBy="2" Modified="2014-11-28T20:15:31.953" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1667" State="1" FileAs="Классификатор объемов заказа" Key="SizeOfServiceRequestView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.SizeOfServiceRequestGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.180" CreatedBy="2" Modified="2014-11-28T20:15:40.480" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1668" State="1" FileAs="Поводы" Key="ReasonView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.ReasonGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.207" CreatedBy="2" Modified="2014-11-28T20:15:47.610" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1669" State="1" FileAs="Типы возможностей" Key="OpportunityTypeView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.OpportunityTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.220" CreatedBy="2" Modified="2014-11-28T20:15:55.267" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1670" State="1" FileAs="Типы маркетинговых програм" Key="MarketingProgramTypeView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.MarketingProgramTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.233" CreatedBy="2" Modified="2014-11-28T20:16:02.633" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1671" State="1" FileAs="Типы поводов" Key="ReasonTypeView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.ReasonTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.247" CreatedBy="2" Modified="2014-11-28T20:16:10.943" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1672" State="1" FileAs="Статусы задач" Key="ProjectTaskStatusView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskStatusGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.260" CreatedBy="2" Modified="2014-11-28T20:16:18.960" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1673" State="1" FileAs="Формы обслуживания" Key="ServiceRequestTypeView" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1665" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.273" CreatedBy="2" Modified="2014-11-28T20:16:27.200" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1674" State="1" FileAs="Склад" Key="Warehouse" OrdinalPosition="20" ParentId="1630" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFLSURBVDhPY+wIX5XMyMQ4p3x5KGNn5Or/DEQAkFook4GJgZGhBcomCzAxMjJKQNlkASYoTTYYYgb8////2t9//+OgXDAgygCgxo////0vPvuXQS9StuAyVBgMCBoA1Lzg+18GjXDZgn19yqU7OGX0Ox+XK2x+UCyhBZJnAavCA0T/ni9zVVndwi5rbSAcN0ODmVuI78/Hl5/eLc1Y/Kjy2hGCLlATPSH2/++vEB7LGLBmkBgLvzgfl2GgOsPv74lEhQHT/39C75Zl871ZkPzv97OrDK9nR//7sL6am5HxPy9JsfDj2i6mlxM8GH7ePgTXxwIMpNcM/xkmgjjImQQG7uZJyjEwMEN5mACUG6OAGaoXV54AGfqoRMLjPwPzZGDGUYEKM/z7//8y49+/uRg24gJXQhnY+OSk8v8zMuYDI7f15MNns8JWM/wFAPxTd3Q2FkBzAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAARzSURBVFhH7VdvTFtVFL/vvb4HtKWlK5QSikUgjlEoZLQim7rQBNCoiQti1CWahU+amGX6ZUaTwYiJMVlizDITzabRTM1EkyUobEQEARkSBisymO1KZbYwKC1/Ci3te32e2z4qENTNR7cv+yWHe8+fe8/v3FvuvQ/daxBCi4yZlRpzUY2JROglUNOvTHZ+NTXrGHm2ouGDWIR4TC84R1qHPz8qqFHECVQZ6mpqS55/GUxPgKq4ZD3/rmP2t65Xq5u7YhHiYZ8Z7frkpxNVghoFFBwDwRMlODlBEGoQWjAnHHECADnIrlj37mEjAQSVx7fkbmETgXuB+wTuE0gYAZ7nWZAlkEmQRZCw4NqERK7ACo/QNcSjM9C3gixFrVuwowSgygiuFP5chMQn3B7H0Y8vHfvCPWd/E/RGIPSDEBrHjhGAxF5I8CskOpWffPnTYkWb1azt1z5jmH/RrB3MKla2j+Wm9HcI4XGIIgBJOZAAiN3rn+2eWxz/Jp22nc1X9kwZ03/ebdnteuVYXeXbVYU3DxvVvUXlqmGyRIlUMFQSm0H8CoRAXDziTw/aut9qHz3+mUVzKjsjxdtMyTVNSXrTk4rqN+S4peTqJkOO8v0LDVkPF+mQIjZ8A5P/BR5NcIg7Ykr9btn02LiJ5fUHaKm0LMX4dF5ywT4FnbWHolI1hET9AB2eHlcE7b+UBaytzSdrmZHllUAb4vz9ogjIJPPLetn3QznSPw4r1dJaWmcuZXSlWUyumWK0D5GUPD0aR8lU0FeTZKpGJVFll5X/eTUz7B7Tsj7XflFbIKV8RJ5kgJRLfHVEsqyGzijIlJnqyST9XmI9+Tqwju3YT2sKNAQjqyEQ8booAnB3EwzFwRy8hJ1zsEFb70rYfS0UWVuNCCGbwIMd+4O2Pj/rmYSDiafF/ggRtcbH3hARLpn13EhdbHuPWe44GQpc7w5FwsGYC1qsL4Ed+9k5uxJxbAp+f4gmsA54ylAotEqzt65TgfEfqZXBr5F/4EtuzTEQbbGO7diP46LxgB0jsBGRBRcTGLtI+XvPRlaGWhBuQSexXQiJIyEEomBDJDfvlKxC5bgFPVrxViSMAN5fjK39rRBFIALb6IOTlY1Q+EjmBPNtQTjGw/FleVBjeDRfU1QG3Rtu36TNNjPc6Vm45dSkZRfCOe/cTpZXXVc9C9YOXRplTKF5JYxloNDk6IT/Aki8CI0TLq+J+LJYDPVHqovrn4J/7o8+bH2nZ9r/u0dw/SfO10u1Ffq0g/Bxc4ggif2C+R8Bl3YfT/DnYBHa/yZQeHBvdekL+MvI4vY5yEBodds92w6GDIaxTXe3Bvw9fY2WXRVQRB3s/B6YK37pQNXwIOHH4f74trHTOzA8FbR755E3niRPlafMzSzNRxT1OAyWwYg7uifwd6TTMzHw2iNJukMlisocBVMJR1Q5JCjCLyOCR0M3l0L950aX+k9fXnPBkAAed9tV3gmOH0CSBpN2H09Q9ZD4OSDSQnBcy5krM31N3YgVwgAI/QWdSfG3743JDAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:01.290" CreatedBy="2" Modified="2015-04-06T16:58:48.967" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1675" State="1" FileAs="Расходные накладные" Key="SalesOrderView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.Inventory.SalesOrderGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.300" CreatedBy="2" Modified="2015-04-06T16:59:22.330" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1676" State="1" FileAs="Приходные накладные" Key="PurchaseOrderView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.PurchaseOrderGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.313" CreatedBy="2" Modified="2015-04-06T16:59:15.393" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1677" State="1" FileAs="Акты возврата" Key="ReturnStatementView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.Inventory.ReturnStatementGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.327" CreatedBy="2" Modified="2015-04-06T16:59:32.660" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1678" State="1" FileAs="Инвентаризационные ведомости" Key="InventoryStatementView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.Inventory.InventoryStatementGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.340" CreatedBy="2" Modified="2015-04-06T16:59:43.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1679" State="1" FileAs="Акты списания" Key="WriteoffStatementView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.Inventory.WriteoffStatementGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.353" CreatedBy="2" Modified="2015-06-18T16:59:15.020" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1680" State="1" FileAs="Остатки на складе" Key="InventoryBalanceView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.Inventory.InventoryBalanceGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.367" CreatedBy="2" Modified="2015-04-06T17:01:49.073" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1681" State="1" FileAs="Номенклатура" Key="Products" OrdinalPosition="75" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.380" CreatedBy="2" Modified="2015-04-06T17:02:00.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1682" State="1" FileAs="Базовая номенклатура" Key="AbstractProductView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AbstractProductGridControl, DykBits.Crm.Dictionaries" ParentId="1681" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.393" CreatedBy="2" Modified="2015-01-26T00:16:03.927" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1683" State="1" FileAs="Номенклатура" Key="ProductView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProductGridControl, DykBits.Crm.Dictionaries" ParentId="1681" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.410" CreatedBy="2" Modified="2015-01-26T00:16:14.530" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1684" State="1" FileAs="Категории номенклатуры" Key="ProductCategoryView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.ProductCategoryGridControl, DykBits.Crm.Dictionaries" ParentId="1681" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.420" CreatedBy="2" Modified="2015-01-26T00:16:26.507" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1685" State="1" FileAs="Подкатегории номенклатуры" Key="ProductSubcategoryView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.ProductSubcategoryGridControl, DykBits.Crm.Dictionaries" ParentId="1681" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.437" CreatedBy="2" Modified="2015-01-26T00:16:36.820" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1686" State="1" FileAs="Наценки" Key="PriceMarginView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.PriceMarginGridControl, DykBits.Crm.Dictionaries" ParentId="1681" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.450" CreatedBy="2" Modified="2015-01-26T00:16:48.067" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1687" State="1" FileAs="Продукты питания" Key="MasterMenu" OrdinalPosition="80" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.460" CreatedBy="2" Modified="2015-01-26T00:16:58.303" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1688" State="1" FileAs="Продукты питания" Key="MasterMenuView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.MasterMenuGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.473" CreatedBy="2" Modified="2015-01-26T00:17:20.093" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1689" State="1" FileAs="Типы блюд" Key="DishTypeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.DishTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.490" CreatedBy="2" Modified="2014-11-28T20:19:35.227" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1690" State="1" FileAs="Подтипы блюд" Key="DishSubtypeView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.DishSubtypeGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.503" CreatedBy="2" Modified="2014-11-28T20:19:42.177" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1691" State="1" FileAs="Типы кухни" Key="DishWorldView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.DishWorldGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.517" CreatedBy="2" Modified="2014-11-28T20:19:49.147" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1692" State="1" FileAs="Способы приготовления" Key="DishCookingMethodView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.DishCookingMethodGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.530" CreatedBy="2" Modified="2014-11-28T20:19:57.760" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1693" State="1" FileAs="Ингредиенты" Key="DishIngredientView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.DishIngredientGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.543" CreatedBy="2" Modified="2014-11-28T20:20:09.947" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1694" State="1" FileAs="Сезоны" Key="SeasonView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.SeasonGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.557" CreatedBy="2" Modified="2014-11-28T20:20:17.337" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1695" State="1" FileAs="Способы подачи" Key="DishServingView" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.DishServingGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.570" CreatedBy="2" Modified="2014-11-28T20:20:24.680" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1696" State="1" FileAs="Поводы" Key="DishOccasionView" OrdinalPosition="90" ViewControlTypeName="DykBits.Crm.UI.DishOccasionGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.583" CreatedBy="2" Modified="2014-11-28T20:20:34.193" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1697" State="1" FileAs="Категории блюд" Key="DishCourseView" OrdinalPosition="100" ViewControlTypeName="DykBits.Crm.UI.DishCourseGridControl, DykBits.Crm.Dictionaries" ParentId="1687" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.600" CreatedBy="2" Modified="2014-11-28T20:20:55.317" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1698" State="1" FileAs="Напитки" Key="Beverages" OrdinalPosition="90" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.610" CreatedBy="2" Modified="2015-01-26T00:17:34.380" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1699" State="1" FileAs="Напитки" Key="BeverageView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BeverageGridControl, DykBits.Crm.Dictionaries" ParentId="1698" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.623" CreatedBy="2" Modified="2015-01-26T00:17:48.310" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1700" State="1" FileAs="Типы напитков" Key="BeverageTypeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BeverageTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1698" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.637" CreatedBy="2" Modified="2014-11-28T20:21:16.127" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1701" State="1" FileAs="Подтипы напитков" Key="BeverageSubtypeView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.BeverageSubtypeGridControl, DykBits.Crm.Dictionaries" ParentId="1698" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.653" CreatedBy="2" Modified="2014-11-28T20:21:23.353" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1702" State="1" FileAs="Тара" Key="BeveragePackView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.BeveragePackGridControl, DykBits.Crm.Dictionaries" ParentId="1698" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.667" CreatedBy="2" Modified="2014-11-28T20:21:33.997" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1703" State="1" FileAs="Специальные предложения" Key="BeverageMiscView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.BeverageMiscGridControl, DykBits.Crm.Dictionaries" ParentId="1698" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.680" CreatedBy="2" Modified="2014-11-28T20:21:51.993" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1704" State="1" FileAs="Финансы" Key="Finance" OrdinalPosition="30" ParentId="1630" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAFPSURBVDhPpZMtTANBEIVnphfAIEg9CaQoJCQIIMVUYxEV/OVKXQ0EFMEhgOLaYEivgCIIQoJCkDQ4EmQFoQaBapA03e4wuwyKXNOWL7nM7dybd7s3cxhWjhaQEueImCpnC7h1ccrQI05PUhy5Ys31DUnxhN4PBGkcmFgDZn601ubYdOaMbU8aY2bZdjYlX1OJJ9D4hy/TXqms7Xzo0tGQ63m9WqwNAdR/Ul0MRoLgJhcdX8kbX5CxYRFSSDSDAKsq8cR/A7b7AJjxXQoS70QUIXOagfdU4Yk3QNoQcYlta8n1W+IiI5wh4K4qPN26cC3iPNLwgxsuiXU5Sl5MD/W5J74LgKHbQfP1c9rtoHn7NMrIJTHdVokn1kAmLEOUuE9OjbXcDpLL80bG9k4GL60ST7cj9MS/DSBXLb6F0cmBLvvm93e+lLONa65nytkCfgMnPnNSBIEnHgAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAJcSURBVFhH7ZZNaBNBFMffezMtTSwIQqEnwZsUCh6C4KHopeBNPPSgguipKCooaaAogoJQ1IhiG8FWCoXEg2JP4tVDsRcLXgtCQRQl4KFQv8ruPN9spiXtbO2uTXLQ/GB35u28zLx589+3gf8edO06+crD44T6hTPh9olzWHj6iJ25Y+x8rhtBrl0HQV1x3ZbgBSD0u7Yl+BlA3O26LSEuAy3l3wiAmT8xmzE2PMzGHAkN5wITDkQ28y25lpyrh3btjjBBMFA8fSlukTl7uzxZvKd3ZaqiLxU9raMhAZDWM/nyxGwI4ZxapQ93z174IovuoWxmn7z0BxHhjLitypWJflBHYzTAfE1216dRT1GX+mwLV0d39isil6WwHJbxgnit1Jw30iAR4ogxPC/nfspWurULQzyGhmftuDh5u7d4pXhz2f2bUiyiW5DbMiO+B4alMDTPtaY3kqWebUvxn0iq9jsnz+eC7z+HmOGxmMuy+LS03XZsM6lEmFTtaxkzbBYlye9CNqMK6Zk88o4hVQBJ1S5pzl588qCns6tjLzH0yeLXJf29tVk2kk6E26jdAIyK14p9nsl2VhXhW1Q4g4SDtQl80gWAeF/OdSFe7fBSJrshXrFnvRWpApDUF2SnBzSp6ZFK6aPdqbRVUFBm4kEDPCZuse/7VqQKQIEqyjEsGoZh/mVydvfBtx/7rQ2M8wR41b5qzj0RqQKQyfuJqGjPtl4DkU1YkvFDzjUx6TTQBNoBtAPwsMrOV0qvndl0vAxEXzyAm85sOt7/gXxl/CiheuXMhmOLl+u2EQB+A7oLHIdLbiqxAAAAAElFTkSuQmCC" NodeType="1" Created="2014-11-26T16:43:01.693" CreatedBy="2" Modified="2015-01-26T00:09:58.763" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1705" State="1" FileAs="ПРС" Key="Budgets" DefaultViewId="3064" OrdinalPosition="10" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACMSURBVDhPzZFLDoAgDESLN2NrSLwLrF255y4G4pajocUxEn/xl+jbdNpMyjTQ5wjUFWXdRshDCtTb7CbYYiuVOBu1ayoRB7z3pJRKM2PM8xMuLeDXpzpp0lpzsoRzDirGfM6avayXnue/wFuklGhnQghQI9ba5EU7k0fN4y2jwr7inROgD+ETIH8FUQ+6CXset2JKOQAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACySURBVFhH7dOxDcMgEAVQyGZ0KWAZ6FNkAJaBIh2jObrTT6JIdgQYC8m518AhhM58rMTf0xibuPtjwXS3C8ZppIEu3vtlTUoJs29b63RO1w3EGPUa5xyP2FaFN4981el21fTFKH8qpRzTAF0vSpZzVtZaVB8hhPmPcHoEbOSrpvNQvg3/C0biCKgTYwwv7EFXSr+oRNBCIjhnBK+bqDY6ghbnjABlPYmgp/MtXRGIeZR6Agl7dPolDrJmAAAAAElFTkSuQmCC" NodeType="2" Created="2014-11-26T16:43:01.707" CreatedBy="2" Modified="2015-03-16T12:54:14.753" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1706" State="1" FileAs="Все ПРС" Key="AllBudgets" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BudgetGridControl, DykBits.Crm.Dictionaries" Parameter="AllBudgets" ParentId="1705" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.720" CreatedBy="2" Modified="2015-03-16T03:16:25.370" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1707" State="1" FileAs="Операционные расходы" Key="OperatingBudgetView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.Operations.OperatingBudgetGridControl, DykBits.Crm.Dictionaries" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.747" CreatedBy="2" Modified="2015-01-26T00:11:32.927" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1708" State="1" FileAs="Прайс-листы" Key="PriceListView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.PriceListGridControl, DykBits.Crm.Dictionaries" ParentId="3067" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.760" CreatedBy="2" Modified="2015-03-30T15:53:52.127" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1709" State="1" FileAs="Движение денежных средств" Key="CashFlow" OrdinalPosition="40" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.773" CreatedBy="2" Modified="2015-01-26T00:11:54.410" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1710" State="1" FileAs="Операции с ДС" Key="MoneyOperationView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.787" CreatedBy="2" Modified="2015-01-26T00:12:06.607" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1711" State="1" FileAs="ДДС по типу операции" Key="MoneyOperationReportByOperationTypeView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationReportByOperationTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.800" CreatedBy="2" Modified="2015-04-05T23:39:59.247" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1712" State="2" FileAs="Сводный бюджет" Key="ConsolidatedBudgetView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.Reports.ConsolidatedBudgetGridControl, DykBits.Crm.Dictionaries" ParentId="2039" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.813" CreatedBy="2" Modified="2015-01-26T00:13:22.273" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1713" State="1" FileAs="Типы операций с ДС" Key="MoneyOperationTypeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.827" CreatedBy="2" Modified="2015-04-05T23:39:38.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1714" State="1" FileAs="Счета" Key="Invoices" OrdinalPosition="50" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.840" CreatedBy="2" Modified="2015-01-26T15:38:08.657" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1715" State="1" FileAs="Счета от поставщиков" Key="PurchaseInvoiceView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.PurchaseInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1714" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.853" CreatedBy="2" Modified="2015-01-26T00:12:19.180" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1716" State="1" FileAs="Счета клиентам" Key="SalesInvoiceView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.SalesInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1714" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.867" CreatedBy="2" Modified="2015-01-26T00:12:28.427" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1717" State="1" FileAs="Шаблоны ПРС" Key="BudgetTemplates" OrdinalPosition="60" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:01.880" CreatedBy="2" Modified="2014-11-28T20:11:08.687" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1718" State="1" FileAs="Шаблоны ПРС" Key="BudgetTemplateView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1717" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.893" CreatedBy="2" Modified="2014-11-28T20:11:21.897" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1719" State="1" FileAs="Разделы ПРС" Key="BudgetItemGroupView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGroupGridControl, DykBits.Crm.Dictionaries" ParentId="1717" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.907" CreatedBy="2" Modified="2014-11-28T20:11:32.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1720" State="1" FileAs="Статьи ПРС" Key="BudgetItemView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGridControl, DykBits.Crm.Dictionaries" ParentId="1717" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.920" CreatedBy="2" Modified="2014-11-28T20:11:41.470" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1721" State="1" FileAs="Связи статей ПРС" Key="BudgetItemLinkView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.BudgetItemLinkGridControl, DykBits.Crm.Dictionaries" ParentId="1717" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.933" CreatedBy="2" Modified="2014-11-28T20:12:16.863" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1722" State="1" FileAs="Справочники" Key="Dictionaries" OrdinalPosition="40" ParentId="1630" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABOSURBVDhPYxhwwAgiMjMz/4N5JIDp06eD9TKBeRQAig0AA5AXkMHmzZuhLAhA5yN7mWIXsEBphi1btkBZEECIjwJGvUAZoDgpDzRgYAAAHqGgPbMorDcAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABwSURBVFhH7dTRCYAwDEXR6GZZKYNkmQ6Q0RRLCIqI/tgn+M6PKQgGvFQIbcqnmNmS4xDu3r899xMQF4AvULYI77TWcrr25J198PwF8AUOF5Gq5uldEVEXUWGEKIywMEIURlgYIcq3IsxxiFOE9FMiK480xx1ml800AAAAAElFTkSuQmCC" NodeType="1" Created="2014-11-26T16:43:01.950" CreatedBy="2" Modified="2014-11-28T20:06:04.287" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1723" State="1" FileAs="Виды деятельности" Key="BusinessActivityTypeView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BusinessActivityTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.960" CreatedBy="2" Modified="2014-11-28T20:09:38.583" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1724" State="1" FileAs="Группы контактов" Key="ContactGroupView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ContactGroupGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.973" CreatedBy="2" Modified="2014-11-28T20:09:47.520" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1725" State="1" FileAs="Группы контрагентов" Key="AccountGroupView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountGroupGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:01.987" CreatedBy="2" Modified="2014-11-28T20:09:58.297" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1726" State="1" FileAs="Должности" Key="PositionView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.PositionGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02" CreatedBy="2" Modified="2014-11-28T20:10:14.660" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1727" State="1" FileAs="Единицы измерения" Key="UnitOfMeasureView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.UnitOfMeasureGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.017" CreatedBy="2" Modified="2014-11-28T20:22:14.560" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1728" State="1" FileAs="Источники" Key="LeadSourceView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.LeadSourceGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.030" CreatedBy="2" Modified="2014-11-28T20:22:22.240" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1729" State="1" FileAs="Места хранения" Key="StoragePlaceView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.StoragePlaceGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.043" CreatedBy="2" Modified="2014-11-28T20:22:29.383" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1730" State="1" FileAs="Нумераторы" Key="DocumentNumberingRuleView" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.DocumentNumberingRuleGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.057" CreatedBy="2" Modified="2014-11-28T20:22:37.217" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1731" State="1" FileAs="Поводы" Key="ReasonView" OrdinalPosition="90" ViewControlTypeName="DykBits.Crm.UI.ReasonGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.070" CreatedBy="2" Modified="2014-11-28T20:22:44.817" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1732" State="1" FileAs="Типы возможностей" Key="OpportunityTypeView" OrdinalPosition="100" ViewControlTypeName="DykBits.Crm.UI.OpportunityTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.080" CreatedBy="2" Modified="2014-11-28T20:22:51.867" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1733" State="1" FileAs="Тип единиц измерения" Key="UnitOfMeasureClassView" OrdinalPosition="110" ViewControlTypeName="DykBits.Crm.UI.UnitOfMeasureClassGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.097" CreatedBy="2" Modified="2014-11-28T20:22:59.410" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1734" State="1" FileAs="Типы контрагентов" Key="AccountTypeView" OrdinalPosition="120" ViewControlTypeName="DykBits.Crm.UI.AccountTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.110" CreatedBy="2" Modified="2014-11-28T20:23:07.107" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1735" State="1" FileAs="Типы маркетинговых програм" Key="MarketingProgramTypeView" OrdinalPosition="130" ViewControlTypeName="DykBits.Crm.UI.MarketingProgramTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.123" CreatedBy="2" Modified="2014-11-28T20:23:14.650" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1736" State="1" FileAs="Типы площадки" Key="VenueTypeView" OrdinalPosition="140" ViewControlTypeName="DykBits.Crm.UI.VenueTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.137" CreatedBy="2" Modified="2014-11-28T20:23:21.560" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1737" State="1" FileAs="Торговые марки" Key="TradeMarkView" OrdinalPosition="150" ViewControlTypeName="DykBits.Crm.UI.TradeMarkGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.150" CreatedBy="2" Modified="2014-11-28T20:23:28.937" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1738" State="1" FileAs="Расположение площадки" Key="VenuePlaceView" OrdinalPosition="160" ViewControlTypeName="DykBits.Crm.UI.VenuePlaceGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.163" CreatedBy="2" Modified="2014-11-28T20:23:35.977" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1739" State="1" FileAs="Регионы" Key="RegionView" OrdinalPosition="170" ViewControlTypeName="DykBits.Crm.UI.RegionGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.177" CreatedBy="2" Modified="2014-11-28T20:23:43.187" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1740" State="1" FileAs="Ставки НДС" Key="VATRateView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.VATRateGridControl, DykBits.Crm.Dictionaries" ParentId="3052" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.190" CreatedBy="2" Modified="2015-03-04T02:33:01.387" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1741" State="1" FileAs="Страны" Key="CountryView" OrdinalPosition="190" ViewControlTypeName="DykBits.Crm.UI.CountryGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.203" CreatedBy="2" Modified="2014-11-28T20:23:58.977" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1742" State="1" FileAs="Отрасли" Key="IndustryView" OrdinalPosition="200" ViewControlTypeName="DykBits.Crm.UI.IndustryGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.217" CreatedBy="2" Modified="2014-11-28T20:24:07.793" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1743" State="1" FileAs="Формы обслуживания" Key="ServiceRequestTypeView" OrdinalPosition="210" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestTypeGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.230" CreatedBy="2" Modified="2014-11-28T20:24:15.570" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1744" State="1" FileAs="Цвета" Key="ItemColorView" OrdinalPosition="220" ViewControlTypeName="DykBits.Crm.UI.ItemColorGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.240" CreatedBy="2" Modified="2014-11-28T20:24:22.880" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1745" State="1" FileAs="Шаблоны событий" Key="AccountEventTemplateView" OrdinalPosition="230" ViewControlTypeName="DykBits.Crm.UI.AccountEventTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1722" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.257" CreatedBy="2" Modified="2014-11-28T20:24:32.907" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1746" State="1" FileAs="Администрирование" Key="Administation" OrdinalPosition="50" ParentId="1630" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAHfSURBVDhPYywqKvrPQALo6+tjhDIhAGQAsQCbZUxQGg4W7b3BENa2nSGqcwfDxuP3oKK4AYoBBy49YVh58BbD1x+/GT5+/cUwa/sVhqsP30FlsQMUA249/QBlIcCNxyQYoCYtAGUhgLWmZB+QsgLij2ABNIBigIOeDEN7ohWDmAAngwgfxw8LDTHv3x2qRx6VSqsDpSNAMfCwRCrhUYlkIEQHAwM4Gnt7exlevv/GMHHjBYZnb78yTMiwY/jz59+V97VKThzszM9BCoHBXwPWwMDQAqJ//PwrqTb5xWu4CwpnHWK4eO8Nw+uP3xmW7b/JsOrwbR3VSc+Z//9n2M3IyMjMxMjYDsIgNkgMpBmkD24AKNRhYOup+/+yfPR47xdI8zMyMjiBxP7//7cVhEFskNi9fCmQtxhYQAQIbG3yg7IYPgJtEXj0XfotKxuTEEjg37//y+R7n0WD2A+LpZcyMTFGsbIx3nhYIv0ObEBxcTGIggF+KE0UQE3XaOBBsYQWEyPzeaCL2ICu2AESA9ruAUzVv/79/2uo0PviGl4DQADo5O0gTVAuGIAMk+996gli4zXgVq6EKCIa/9cz/mdgBoZgHYgPi0YQGy94UCwdAko8UC7Do2LJZJAYhMfAAAA3X9381m7axgAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAO5SURBVFhHxZdpSFRRFMfPfU2mYdiCtIlhiEhCWIbaAkU5KhQFohL1JfSDiB8kJgiLUFtIyhEqWhCFCgs3EqQFMyPJSEHFIMU2E3VUsoWhcmNmXufcufMYnfH5XjX4gzv3nHPvm/Ofu76BhYbRR0FBgcw9H4I5eC6vkABfI1J5oIxAfn4+DxQWFvLal3iMhvsI+Ho06PtFWo4k6gXjrwSMWSfh5uMeyLzaDAfPNfD6+qNuHteLbgFdfd8g51YLPOkYVBJS3dA5xOPUrgddAihRUW0XTE7bRWQmFKd2PSOhS8CD159hfMomPO9QO/XTii4Brb1fhKWO1n6ELgHW8WlhqaO1H6FLQNBSP2Gpo7UfoUtAbESwsNTR2o/QJSBlRxj4+y0SnneonfppRZeA1csD4FTaljlFULz6ZMIF7LcZ3TFnlGPBEomlhHtu6BJARG9cBdeydkLS1hBYEbiEx6iOiwjux+QbBkv21VvMiTEYTsNCq3ECyyGMbce2qtkXkW4BBI1Ezv4ouHN8D9SfSaK6NONTbuyIOfHiYmZokxiUjZQkBGDXKCpoB1OM2oaLjfeGL+xSFokmAXS41L76DGcrO+HwpSYouN8hWhSSYc1autxTyWGM4RxJlSMlSVRqyHbGqBFSbf425SidV8DL7lHIuNIMd5+/h/YPY1xM56ev3HYjdG1GdbQMcr3wSUQQYxDjLCxIhIH6hJpavwtXXcCPX1Nw7eFbr8dvxYsP4Jj5ohOG3+4xNLNhwD4Kk6MqoOnN8JwXT9/oTyh72luLZgqWyJp0Vs6YxKeAwHePX7LDUc4L2iKMMGN1GijbyCBqr9BQq5GVvCntgNl4A3957s544yYcbr64MKHVBtPbQk808187YN5dZJD92l3Tgn1HLHHQg8PRozoCg1/dhM+BxFi2JLHdWLsff7dDTc7kBNkysArh0jPB4plsVQHW39ovlRnIcqCwFJjs8BfmDFQFoEJhzQ2uw1Ic8hbZISsrG7dAav9lo3IecxtjwgXqy5/BZz0y0Fur6xV9Hmh1VmF5h6XnR19H42RdXjuTWDg10jpAJVW47eyY5IhrK2Lyjy1tjZHpNfx55/8Cd2a/NmuFjtjh4oTTTJLOi5BXUFjROlNjnnA9BfwLFnNCjeS2Fb3hkB21603P6J7g/DcBA+b4lQZ52RBOAd0BrikQO0EOd5uCCRv7GeI6DVUXoR4MkwY6XOrIxuR2u0M+us70dBsVsilGbUid6OsbBsx7Yy1mY6ZwFYaKjceoTbgCgD+Ld1Ef8l+7uQAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.270" CreatedBy="2" Modified="2014-11-28T20:06:22.920" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1747" State="1" FileAs="Классы документов" Key="DocumentTypeEntryView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentTypeEntryGridControl, DykBits.Crm.Dictionaries" ParentId="3069" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.283" CreatedBy="2" Modified="2015-04-06T07:15:39.103" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1748" State="1" FileAs="Отчеты" Key="DocumentReportView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.DocumentReportGridControl, DykBits.Crm.Dictionaries" ParentId="3069" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.297" CreatedBy="2" Modified="2015-04-06T07:21:21.567" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1749" State="1" FileAs="Запросы" Key="DataQueryView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.DataQueryGridControl, DykBits.Crm.Dictionaries" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.310" CreatedBy="2" Modified="2014-11-28T20:07:15.887" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1750" State="1" FileAs="Представления" Key="DocumentViewView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.DocumentViewEntryGridControl, DykBits.Crm.Dictionaries" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.320" CreatedBy="2" Modified="2014-11-28T20:07:31.303" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1751" State="1" FileAs="Состояния" Key="DocumentStateEntryView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.DocumentStateEntryGridControl, DykBits.Crm.Dictionaries" ParentId="3069" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.337" CreatedBy="2" Modified="2015-04-06T07:16:45.170" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1752" State="1" FileAs="Шаблоны переходов" Key="DocumentTransitionView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.DocumentTransitionGridControl, DykBits.Crm.Dictionaries" ParentId="3069" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.350" CreatedBy="2" Modified="2015-04-06T07:16:51.670" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1753" State="1" FileAs="Пользователи" Key="UserView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.UserGridControl, DykBits.Crm.Dictionaries" ParentId="3070" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.363" CreatedBy="2" Modified="2015-04-06T07:18:54.500" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1756" State="1" FileAs="Роли" Key="ApplicationRoleView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ApplicationRoleGridControl, DykBits.Crm.Dictionaries" ParentId="3070" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.403" CreatedBy="2" Modified="2015-04-06T07:19:21.210" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1757" State="1" FileAs="Права доступа" Key="DocumentAccessControlListView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.DocumentAccessControlListGridControl, DykBits.Crm.Dictionaries" ParentId="3070" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.417" CreatedBy="2" Modified="2015-04-06T07:19:55.433" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1758" State="1" FileAs="Сообщения" Key="ErrorMessageView" OrdinalPosition="120" ViewControlTypeName="DykBits.Crm.UI.ErrorMessageGridControl, DykBits.Crm.Dictionaries" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.430" CreatedBy="2" Modified="2014-11-28T20:08:57.970" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1759" State="1" FileAs="Ошибки" Key="ErrorInformationView" OrdinalPosition="130" ViewControlTypeName="DykBits.Crm.UI.ErrorInformationGridControl, DykBits.Crm.Dictionaries" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.443" CreatedBy="2" Modified="2014-11-28T20:09:07.257" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1760" State="1" FileAs="Интерфейс" Key="PresentationNodeView" OrdinalPosition="140" ViewControlTypeName="DykBits.Crm.UI.Configuration.PresentationNodeGridControl, DykBits.Crm.Dictionaries" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.457" CreatedBy="2" Modified="2014-11-28T20:09:17.177" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1761" State="1" FileAs="Селекторы" Key="Selectors" OrdinalPosition="20" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABaSURBVDhPY6AUMEJpnODJ3hp1FhbWA0yMjBJQITgQs6vDrx+k+cXBxudfHx35jw5eHWr6D1LD+PJgQy8jI1MRWAeJAOQCoMvI0wwDTFCabDBqwKgBgwEwMAAA53IkmYlaqNIAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADGSURBVFhHYxgFIx4wQmmKwaujtd5MTAyrGRkZOaFCWMG///8rRS2bO6Bc6oDXx2qi3pyo//Pj5en/OMG/v/+/3N/8/+2Juv9QbWDABKXJBq+PV2cyMTEt5Zb3YGYXM4GKYgGMTAxcsi5QDgJQ5IA3x2rrmBiZp3HKODNwSFhARUkD8DTw5nhNAiMj03wol6ZA2KIJbi9SCDDOgTLoCuAOAKZeZiiTroDiREgpGHXAqANGHTDqgFEHjDpg1AGjDhgFIx0wMAAAylBBR5vnfvYAAAAASUVORK5CYII=" NodeType="1" Created="2014-11-26T16:43:02.470" CreatedBy="2" Modified="2015-01-29T14:10:43.167" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1762" State="1" FileAs="Участники проекта" Key="ProjectMember" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectMemberGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.483" CreatedBy="2" Modified="2015-03-18T16:47:35.647" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1763" State="1" FileAs="Расчетные счета" Key="BankAccount" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BankAccountGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.500" CreatedBy="2" Modified="2015-01-29T14:40:43.633" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1764" State="1" FileAs="Базовая номенклатура" Key="AbstractProduct" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AbstractProductGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.513" CreatedBy="2" Modified="2015-06-18T19:12:38.783" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1765" State="1" FileAs="Номенклатура" Key="Product" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.ProductGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.527" CreatedBy="2" Modified="2015-06-18T19:12:18.650" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1766" State="1" FileAs="Контрагенты" Key="Account" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.AccountGridControl, DykBits.Crm.Dictionaries" Parameter="MyAccounts" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.540" CreatedBy="2" Modified="2015-06-18T19:11:49.617" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1767" State="1" FileAs="Контакты" Key="Contact" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.ContactGridControl, DykBits.Crm.Dictionaries" Parameter="MyContacts" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.557" CreatedBy="2" Modified="2015-01-29T14:41:12.623" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1768" State="1" FileAs="Организации" Key="Organization" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.OrganizationGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.570" CreatedBy="2" Modified="2015-06-18T19:19:01.050" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1769" State="1" FileAs="Площадки" Key="Venue" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.VenueGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.583" CreatedBy="2" Modified="2015-03-31T13:33:38" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1770" State="1" FileAs="Сотрудники" Key="Employee" OrdinalPosition="90" ViewControlTypeName="DykBits.Crm.UI.EmployeeGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.597" CreatedBy="2" Modified="2015-03-18T16:56:15.537" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1771" State="1" FileAs="Договоры" Key="Contract" OrdinalPosition="100" ViewControlTypeName="DykBits.Crm.UI.ContractGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.610" CreatedBy="2" Modified="2015-01-29T14:41:40.020" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1772" State="1" FileAs="Шаблоны ПРС" Key="BudgetTemplate" OrdinalPosition="110" ViewControlTypeName="DykBits.Crm.UI.BudgetTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.623" CreatedBy="2" Modified="2015-01-29T14:41:47.147" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1773" State="1" FileAs="Проекты" Key="Project" OrdinalPosition="120" ViewControlTypeName="DykBits.Crm.UI.ProjectGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.637" CreatedBy="2" Modified="2015-01-29T14:41:56.663" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1774" State="1" FileAs="Шаблоны проектов" Key="ProjectTemplate" OrdinalPosition="130" ViewControlTypeName="DykBits.Crm.UI.ProjectTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.650" CreatedBy="2" Modified="2015-01-29T14:42:04.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1775" State="1" FileAs="Пользователи" Key="User" OrdinalPosition="140" ViewControlTypeName="DykBits.Crm.UI.UserGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.663" CreatedBy="2" Modified="2015-01-29T14:42:11.670" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1776" State="1" FileAs="Торговые марки" Key="TradeMark" OrdinalPosition="150" ViewControlTypeName="DykBits.Crm.UI.TradeMarkGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.677" CreatedBy="2" Modified="2015-01-29T14:42:19.630" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1777" State="1" FileAs="Разделы ПРС" Key="BudgetItemGroup" OrdinalPosition="160" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGroupGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.690" CreatedBy="2" Modified="2015-01-29T14:42:27.397" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1778" State="1" FileAs="Статьи ПРС" Key="BudgetItem" OrdinalPosition="170" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.703" CreatedBy="2" Modified="2015-01-29T14:42:35.827" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1779" State="1" FileAs="Заказы покупателей" Key="ServiceRequest" OrdinalPosition="180" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestGridControl, DykBits.Crm.Dictionaries" Parameter="MyServiceRequests" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.717" CreatedBy="2" Modified="2015-03-23T17:31:13.603" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1780" State="1" FileAs="Счета от поставщиков" Key="PurchaseInvoice" OrdinalPosition="190" ViewControlTypeName="DykBits.Crm.UI.PurchaseInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.730" CreatedBy="2" Modified="2015-01-29T14:42:51.497" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1781" State="1" FileAs="Счета выставленные клиентам" Key="SalesInvoice" OrdinalPosition="200" ViewControlTypeName="DykBits.Crm.UI.SalesInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.743" CreatedBy="2" Modified="2015-01-29T14:43:06.850" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1782" State="1" FileAs="Сметы" Key="Budget" OrdinalPosition="210" ViewControlTypeName="DykBits.Crm.UI.BudgetGridControl, DykBits.Crm.Dictionaries" Parameter="AllBudgets" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.757" CreatedBy="2" Modified="2015-06-18T19:12:53.510" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1783" State="1" FileAs="Бюджеты" Key="OperatingBudget" OrdinalPosition="220" ViewControlTypeName="DykBits.Crm.UI.Operations.OperatingBudgetGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.770" CreatedBy="2" Modified="2015-01-29T14:43:41.693" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1784" State="1" FileAs="Интерфейс" Key="PresentationNode" OrdinalPosition="230" ViewControlTypeName="DykBits.Crm.UI.Configuration.PresentationNodeGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.783" CreatedBy="2" Modified="2015-01-29T14:43:48.483" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1786" State="1" FileAs="Общие" Key="DocumentTypeEntryEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentTypeEntryEditorControl, DykBits.Crm.Dictionaries" ParentId="1785" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.810" CreatedBy="2" Modified="2014-11-28T20:26:42.983" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1787" State="1" FileAs="Состояния" Key="DocumentStateEntryView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.DocumentStateEntryGridControl, DykBits.Crm.Dictionaries" ParentId="1785" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.823" CreatedBy="2" Modified="2014-11-28T20:26:53.330" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1788" State="1" FileAs="Переходы" Key="DocumentTransitionView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.DocumentTransitionGridControl, DykBits.Crm.Dictionaries" ParentId="1785" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.837" CreatedBy="2" Modified="2014-11-28T20:27:03.393" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1789" State="1" FileAs="Форма редактирования" Key="PresentationNodeView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.Configuration.PresentationNodeGridControl, DykBits.Crm.Dictionaries" ParentId="1785" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:02.850" CreatedBy="2" Modified="2014-11-28T20:27:19.363" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1791" State="1" FileAs="Общие" Key="DocumentReportEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentReportEditorControl, DykBits.Crm.Dictionaries" ParentId="1790" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.877" CreatedBy="2" Modified="2014-11-28T20:27:31.283" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1793" State="1" FileAs="Общие" Key="DataQueryEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DataQueryEditorControl, DykBits.Crm.Dictionaries" ParentId="1792" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.907" CreatedBy="2" Modified="2014-11-28T20:27:40.660" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1795" State="1" FileAs="Общие" Key="DocumentStateEntryEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentStateEntryEditorControl, DykBits.Crm.Dictionaries" ParentId="1794" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.930" CreatedBy="2" Modified="2014-11-28T20:27:48.913" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1797" State="1" FileAs="Общие" Key="DocumentTransitionEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentTransitionEditorControl, DykBits.Crm.Dictionaries" ParentId="1796" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.960" CreatedBy="2" Modified="2014-11-28T20:27:56.760" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1799" State="1" FileAs="Общие" Key="UserEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.UserEditorControl, DykBits.Crm.Dictionaries" ParentId="1798" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:02.987" CreatedBy="2" Modified="2014-11-28T20:28:04.987" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1805" State="1" FileAs="Общие" Key="ApplicationRoleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ApplicationRoleEditorControl, DykBits.Crm.Dictionaries" ParentId="1804" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.067" CreatedBy="2" Modified="2014-11-28T20:28:40.057" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1806" State="1" FileAs="Пользователи" Key="UserView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.UserGridControl, DykBits.Crm.Dictionaries" ParentId="1804" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.080" CreatedBy="2" Modified="2014-11-28T20:28:50" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1808" State="1" FileAs="Роли" Key="DocumentAccessControlListEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentAccessControlListEditorControl, DykBits.Crm.Dictionaries" ParentId="1807" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.107" CreatedBy="2" Modified="2014-11-28T20:34:02.083" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1809" State="1" FileAs="Документы" Key="DocumentAccessControlListByDocumentEditor" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.DocumentAccessControlListByDocumentEditorControl, DykBits.Crm.Dictionaries" ParentId="1807" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.120" CreatedBy="2" Modified="2014-11-28T20:34:13.603" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1811" State="1" FileAs="Общие" Key="ErrorInformationEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ErrorInformationEditorControl, DykBits.Crm.Dictionaries" ParentId="1810" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.147" CreatedBy="2" Modified="2014-11-28T20:34:25.163" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1813" State="1" FileAs="Общие" Key="ErrorMessageEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ErrorMessageEditorControl, DykBits.Crm.Dictionaries" ParentId="1812" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.173" CreatedBy="2" Modified="2014-11-28T20:34:35.507" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1815" State="1" FileAs="Общие" Key="PresentationNodeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Configuration.PresentationNodeEditorControl, DykBits.Crm.Dictionaries" ParentId="1814" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.200" CreatedBy="2" Modified="2014-11-28T20:34:46.597" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1817" State="1" FileAs="Общие" Key="AbstractProductEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AbstractProductEditorControl, DykBits.Crm.Dictionaries" ParentId="1816" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.230" CreatedBy="2" Modified="2015-01-26T00:22:52.620" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1818" State="1" FileAs="Номенклатура" Key="ProductView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProductGridControl, DykBits.Crm.Dictionaries" ParentId="1816" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.243" CreatedBy="2" Modified="2015-01-26T00:22:35.830" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1820" State="1" FileAs="Общие" Key="ProductEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProductEditorControl, DykBits.Crm.Dictionaries" ParentId="1819" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.270" CreatedBy="2" Modified="2015-01-26T00:54:11.117" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1822" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1821" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.297" CreatedBy="2" Modified="2014-11-28T20:35:26.990" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1823" State="1" FileAs="Подкатегории" Key="ProductSubcategoryView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProductSubcategoryGridControl, DykBits.Crm.Dictionaries" ParentId="1821" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.310" CreatedBy="2" Modified="2014-11-28T20:35:37.243" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1825" State="1" FileAs="Общие" Key="ProductSubcategoryEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProductSubcategoryEditorControl, DykBits.Crm.Dictionaries" ParentId="1824" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.337" CreatedBy="2" Modified="2014-11-28T20:35:47.100" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1827" State="1" FileAs="Общие" Key="PriceMarginEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.PriceMarginEditorControl, DykBits.Crm.Dictionaries" ParentId="1826" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.360" CreatedBy="2" Modified="2015-01-26T00:53:44.550" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1829" State="1" FileAs="Общие" Key="MasterMenuEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.MasterMenuEditorControl, DykBits.Crm.Dictionaries" ParentId="1828" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.390" CreatedBy="2" Modified="2015-01-26T01:00:34.383" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1831" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1830" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.417" CreatedBy="2" Modified="2014-11-28T20:51:34.220" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1832" State="1" FileAs="Подтипы" Key="DishSubtypeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.DishSubtypeGridControl, DykBits.Crm.Dictionaries" ParentId="1830" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.430" CreatedBy="2" Modified="2014-11-28T20:51:43.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1834" State="1" FileAs="Общие" Key="DishSubtypeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DishSubtypeEditorControl, DykBits.Crm.Dictionaries" ParentId="1833" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.457" CreatedBy="2" Modified="2014-11-28T20:51:52.797" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1836" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1835" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.483" CreatedBy="2" Modified="2014-11-28T20:52:03.270" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1838" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1837" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.510" CreatedBy="2" Modified="2014-11-28T20:52:12.157" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1840" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1839" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.540" CreatedBy="2" Modified="2014-11-28T20:52:20.357" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1842" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1841" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.567" CreatedBy="2" Modified="2014-11-28T20:52:28.677" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1844" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1843" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.593" CreatedBy="2" Modified="2014-11-28T20:52:36.877" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1846" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1845" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.620" CreatedBy="2" Modified="2014-11-28T20:52:45.443" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1848" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1847" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.647" CreatedBy="2" Modified="2014-11-28T20:52:54.203" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1850" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1849" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.673" CreatedBy="2" Modified="2014-11-28T20:53:02.123" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1852" State="1" FileAs="Общие" Key="BeverageEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BeverageEditorControl, DykBits.Crm.Dictionaries" ParentId="1851" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.700" CreatedBy="2" Modified="2015-01-26T00:53:17.733" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1854" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1853" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.727" CreatedBy="2" Modified="2014-11-28T20:53:24.260" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1855" State="1" FileAs="Подтипы" Key="BeverageSubtypeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BeverageSubtypeGridControl, DykBits.Crm.Dictionaries" ParentId="1853" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.740" CreatedBy="2" Modified="2014-11-28T20:53:33.493" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1857" State="1" FileAs="Общие" Key="BeverageSubtypeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BeverageSubtypeEditorControl, DykBits.Crm.Dictionaries" ParentId="1856" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.767" CreatedBy="2" Modified="2014-11-28T20:53:42.483" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1859" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1858" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.793" CreatedBy="2" Modified="2014-11-28T20:53:50.630" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1861" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1860" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.820" CreatedBy="2" Modified="2014-11-28T20:53:59.100" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1863" State="1" FileAs="Общие" Key="BudgetItemGroupEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGroupEditorControl, DykBits.Crm.Dictionaries" ParentId="1862" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.847" CreatedBy="2" Modified="2014-11-28T20:54:07.773" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1864" State="1" FileAs="Статьи ПРС" Key="BudgetItemView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.BudgetItemGridControl, DykBits.Crm.Dictionaries" ParentId="1862" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.860" CreatedBy="2" Modified="2014-11-28T20:54:17.803" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1866" State="1" FileAs="Общие" Key="BudgetItemEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetItemEditorControl, DykBits.Crm.Dictionaries" ParentId="1865" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.887" CreatedBy="2" Modified="2014-11-28T20:54:27.413" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1868" State="1" FileAs="Общие" Key="BudgetItemLinkEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetItemLinkEditorControl, DykBits.Crm.Dictionaries" ParentId="1867" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.913" CreatedBy="2" Modified="2014-11-28T20:54:39.220" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1870" State="1" FileAs="Общие" Key="CalculationStatementTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CalculationStatementTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1869" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.940" CreatedBy="2" Modified="2015-01-26T01:04:55.513" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1872" State="1" FileAs="Общие" Key="BudgetTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1871" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:03.970" CreatedBy="2" Modified="2015-01-26T01:05:24.237" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1873" State="1" FileAs="Шаблоны калькуляций" Key="CalculationStatementTemplateView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.CalculationStatementTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1871" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:03.980" CreatedBy="2" Modified="2015-01-26T01:05:34.520" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1875" State="1" FileAs="Общие" Key="SalesOrderEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.SalesOrderEditorControl, DykBits.Crm.Dictionaries" ParentId="1874" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.010" CreatedBy="2" Modified="2015-04-06T16:58:23.020" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1879" State="1" FileAs="Общие" Key="WriteoffStatementEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.WriteoffStatementEditorControl, DykBits.Crm.Dictionaries" ParentId="1878" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.063" CreatedBy="2" Modified="2015-06-25T11:57:05.217" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1881" State="1" FileAs="Общие" Key="ReturnStatementEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.ReturnStatementEditorControl, DykBits.Crm.Dictionaries" ParentId="1880" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.090" CreatedBy="2" Modified="2015-01-26T00:21:57.513" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1883" State="1" FileAs="Общие" Key="InventoryStatementEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.InventoryStatementEditorControl, DykBits.Crm.Dictionaries" ParentId="1882" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.117" CreatedBy="2" Modified="2015-01-26T00:28:02.367" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1887" State="1" FileAs="Общие" Key="OperatingBudgetEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Operations.OperatingBudgetEditorControl, DykBits.Crm.Dictionaries" ParentId="1886" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.170" CreatedBy="2" Modified="2015-01-26T00:25:27.723" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1888" State="1" FileAs="Калькуляции" Key="OperatingCalculationView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.Operations.OperatingCalculationGridControl, DykBits.Crm.Dictionaries" ParentId="1886" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.183" CreatedBy="2" Modified="2015-01-26T00:25:15.520" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1889" State="1" FileAs="Выставленные счета" Key="SalesInvoiceView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.SalesInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1886" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.197" CreatedBy="2" Modified="2015-01-26T00:24:54.217" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1890" State="1" FileAs="Полученные счета" Key="PurchaseInvoiceView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.PurchaseInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1886" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.210" CreatedBy="2" Modified="2015-01-26T00:25:37.937" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1891" State="1" FileAs="ДДС" Key="MoneyOperationView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1886" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.223" CreatedBy="2" Modified="2015-01-26T00:25:04.830" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1885" State="1" FileAs="Общие" Key="EstimatesTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.EstimatesTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1884" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.143" CreatedBy="2" Modified="2015-01-26T01:06:00.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1893" State="1" FileAs="Общие" Key="OperatingCalculationEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Operations.OperatingCalculationEditorControl, DykBits.Crm.Dictionaries" ParentId="1892" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.253" CreatedBy="2" Modified="2015-01-26T00:51:22.437" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1897" State="1" FileAs="Общие" Key="BudgetEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetEditorControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.307" CreatedBy="2" Modified="2015-03-16T13:37:33.907" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1898" State="1" FileAs="Калькуляции" Key="CalculationStatementView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.CalculationStatementGridControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.320" CreatedBy="2" Modified="2015-03-16T13:37:05.957" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1899" State="1" FileAs="Выставленные счета" Key="SalesInvoiceView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.SalesInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.333" CreatedBy="2" Modified="2015-01-26T00:23:45.257" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1900" State="1" FileAs="Полученные счета" Key="PurchaseInvoiceView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.PurchaseInvoiceGridControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.350" CreatedBy="2" Modified="2015-01-26T00:24:29.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1901" State="1" FileAs="ДДС" Key="MoneyOperationView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.367" CreatedBy="2" Modified="2015-01-26T00:23:56.037" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1905" State="1" FileAs="Общие" Key="AccountEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountEditorControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.420" CreatedBy="2" Modified="2015-01-26T00:52:49.887" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1906" State="1" FileAs="Дополнительно" Key="AccountLegalEditor" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.AccountLegalEditorControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.437" CreatedBy="2" Modified="2015-01-26T00:52:09.837" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1907" State="1" FileAs="Маркетинг" Key="AccountDetailsEditor" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountDetailsEditorControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.450" CreatedBy="2" Modified="2014-11-28T21:02:51.797" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1908" State="1" FileAs="Контакты" Key="ContactView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.ContactGridControl, DykBits.Crm.Dictionaries" Parameter="AllContacts" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.463" CreatedBy="2" Modified="2015-01-26T00:52:35.390" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1909" State="1" FileAs="События" Key="AccountEventView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" Parameter="AllAccountEvents" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.477" CreatedBy="2" Modified="2014-11-28T21:03:09.500" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1910" State="1" FileAs="Банковские счета" Key="BankAccountView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.BankAccountGridControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.490" CreatedBy="2" Modified="2015-01-26T00:51:56.270" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1911" State="1" FileAs="Договоры" Key="ContractView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.ContractGridControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.503" CreatedBy="2" Modified="2014-11-28T21:03:26.137" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1912" State="1" FileAs="Заказы" Key="ServiceRequestView" OrdinalPosition="80" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestGridControl, DykBits.Crm.Dictionaries" Parameter="AllServiceRequests" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.520" CreatedBy="2" Modified="2015-01-26T00:52:22.543" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1913" State="1" FileAs="Доступ" Key="DocumentEmployeeAccessRightView" OrdinalPosition="90" ViewControlTypeName="DykBits.Crm.UI.DocumentEmployeeAccessRightGridControl, DykBits.Crm.Dictionaries" ParentId="1904" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.533" CreatedBy="2" Modified="2014-11-28T21:03:42.960" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1895" State="1" FileAs="Общие" Key="PayrollEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Operations.PayrollEditorControl, DykBits.Crm.Dictionaries" ParentId="1894" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.280" CreatedBy="2" Modified="2015-01-26T01:01:42.320" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1903" State="1" FileAs="Общие" Key="EstimatesDocumentEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.EstimatesDocumentEditorControl, DykBits.Crm.Dictionaries" ParentId="1902" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.393" CreatedBy="2" Modified="2015-01-26T01:03:27.670" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1915" State="1" FileAs="Общие" Key="OrganizationEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.OrganizationEditorControl, DykBits.Crm.Dictionaries" ParentId="1914" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.560" CreatedBy="2" Modified="2015-01-26T00:55:22.147" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1916" State="1" FileAs="Сотрудники" Key="EmployeeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.EmployeeGridControl, DykBits.Crm.Dictionaries" ParentId="1914" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.573" CreatedBy="2" Modified="2015-01-26T00:55:47.027" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1917" State="1" FileAs="Банковские счета" Key="BankAccountView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.BankAccountGridControl, DykBits.Crm.Dictionaries" ParentId="1914" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.587" CreatedBy="2" Modified="2015-01-26T00:55:09.720" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1918" State="1" FileAs="Подразделения" Key="DivisionView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.DivisionGridControl, DykBits.Crm.Dictionaries" ParentId="1914" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.600" CreatedBy="2" Modified="2015-01-26T00:55:34.263" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1919" State="1" FileAs="Договоры" Key="ContractView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.ContractGridControl, DykBits.Crm.Dictionaries" ParentId="1914" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.613" CreatedBy="2" Modified="2014-11-28T21:00:14.940" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1924" State="1" FileAs="Общие" Key="EmployeeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.EmployeeEditorControl, DykBits.Crm.Dictionaries" ParentId="1923" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.680" CreatedBy="2" Modified="2015-01-26T01:03:59.530" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1925" State="1" FileAs="Подробно" Key="EmployeeDetailsEditor" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.EmployeeDetailsEditorControl, DykBits.Crm.Dictionaries" ParentId="1923" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.693" CreatedBy="2" Modified="2015-01-26T01:04:11.053" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1926" State="1" FileAs="З/П" Key="EmployeeSalaryEditor" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.EmployeeSalaryEditorControl, DykBits.Crm.Dictionaries" ParentId="1923" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.707" CreatedBy="2" Modified="2014-11-28T20:59:30.653" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1927" State="1" FileAs="События" Key="AccountEvent" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" ParentId="1923" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.720" CreatedBy="2" Modified="2014-11-28T20:58:52.487" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1929" State="1" FileAs="Общие" Key="ContactEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ContactEditorControl, DykBits.Crm.Dictionaries" ParentId="1928" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.747" CreatedBy="2" Modified="2014-11-28T20:58:45.807" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1930" State="1" FileAs="Подробно" Key="ContactDetailsEditor" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ContactDetailsEditorControl, DykBits.Crm.Dictionaries" ParentId="1928" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.760" CreatedBy="2" Modified="2014-11-28T20:58:39.980" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1931" State="1" FileAs="События" Key="AccountEventView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" ParentId="1928" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.773" CreatedBy="2" Modified="2014-11-28T20:58:33.590" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1933" State="1" FileAs="Общие" Key="AccountEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountEditorControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.800" CreatedBy="2" Modified="2014-11-28T20:58:26.860" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1934" State="1" FileAs="Площадка" Key="VenueEditor" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.VenueEditorControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.813" CreatedBy="2" Modified="2014-11-28T20:58:20.163" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1935" State="1" FileAs="Дополнительно" Key="AccountLegalEditor" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountLegalEditorControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.827" CreatedBy="2" Modified="2014-11-28T20:58:13.340" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1936" State="1" FileAs="Маркетинг" Key="AccountDetailsEditor" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.AccountDetailsEditorControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.840" CreatedBy="2" Modified="2014-11-28T20:58:06.357" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1937" State="1" FileAs="Контакты" Key="ContactView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.ContactGridControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.853" CreatedBy="2" Modified="2014-11-28T20:51:04.700" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1938" State="1" FileAs="События" Key="AccountEventView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.867" CreatedBy="2" Modified="2014-11-28T20:50:56.507" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1939" State="1" FileAs="Банковские счета" Key="BankAccountView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.BankAccountGridControl, DykBits.Crm.Dictionaries" ParentId="1932" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.880" CreatedBy="2" Modified="2014-11-28T20:50:47.943" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1941" State="1" FileAs="Общие" Key="ProjectEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectEditorControl, DykBits.Crm.Dictionaries" ParentId="1940" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.907" CreatedBy="2" Modified="2014-11-28T20:50:41.453" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1942" State="1" FileAs="Участники" Key="ProjectMemberView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProjectMemberGridControl, DykBits.Crm.Dictionaries" ParentId="1940" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.920" CreatedBy="2" Modified="2014-11-28T20:50:34.677" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1943" State="1" FileAs="Задачи" Key="ProjectTaskView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskGridControl, DykBits.Crm.Dictionaries" ParentId="1940" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.933" CreatedBy="2" Modified="2014-11-28T20:50:26.083" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1921" State="1" FileAs="Общие" Key="DivisionEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DivisionEditorControl, DykBits.Crm.Dictionaries" ParentId="1920" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.640" CreatedBy="2" Modified="2015-01-26T00:56:44.933" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1922" State="1" FileAs="Сотрудники" Key="EmployeeView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.EmployeeGridControl, DykBits.Crm.Dictionaries" ParentId="1920" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:04.653" CreatedBy="2" Modified="2015-01-26T00:56:58.360" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1945" State="1" FileAs="Общие" Key="ProjectTaskEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskEditorControl, DykBits.Crm.Dictionaries" ParentId="1944" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.960" CreatedBy="2" Modified="2014-11-28T20:50:18.787" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1947" State="1" FileAs="Общие" Key="ProjectMemberEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectMemberEditorControl, DykBits.Crm.Dictionaries" ParentId="1946" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:04.987" CreatedBy="2" Modified="2015-03-24T14:41:02.553" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1949" State="1" FileAs="Общие" Key="ProjectTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1948" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.013" CreatedBy="2" Modified="2014-11-28T20:50:04.750" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1950" State="1" FileAs="Задачи" Key="ProjectTaskTemplateView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskTemplateGridControl, DykBits.Crm.Dictionaries" ParentId="1948" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.027" CreatedBy="2" Modified="2014-11-28T20:49:57.507" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1952" State="1" FileAs="Общие" Key="ProjectTaskTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1951" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.053" CreatedBy="2" Modified="2014-11-28T20:49:49.610" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1954" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="1953" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.080" CreatedBy="2" Modified="2014-11-28T20:49:42.293" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1956" State="1" FileAs="Общие" Key="ServiceRequestEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestEditorControl, DykBits.Crm.Dictionaries" ParentId="1955" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.107" CreatedBy="2" Modified="2015-03-23T17:33:57.610" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1957" State="1" FileAs="Задачи" Key="ProjectTaskView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskGridControl, DykBits.Crm.Dictionaries" ParentId="1955" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.120" CreatedBy="2" Modified="2014-11-28T20:49:28.750" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1958" State="1" FileAs="События" Key="AccountEventView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.AccountEventGridControl, DykBits.Crm.Dictionaries" Parameter="AllAccountEvents" ParentId="1955" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.130" CreatedBy="2" Modified="2014-11-28T20:49:21.760" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1961" State="1" FileAs="Общие" Key="BankAccountEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BankAccountEditorControl, DykBits.Crm.Dictionaries" ParentId="1960" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.170" CreatedBy="2" Modified="2015-01-26T00:23:16.633" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1963" State="1" FileAs="Общие" Key="ContractEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ContractEditorControl, DykBits.Crm.Dictionaries" ParentId="1962" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.200" CreatedBy="2" Modified="2014-11-28T20:48:58.163" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1964" State="1" FileAs="Приложения" Key="ContractView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ContractGridControl, DykBits.Crm.Dictionaries" ParentId="1962" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.213" CreatedBy="2" Modified="2014-11-28T20:48:40.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1966" State="1" FileAs="Общие" Key="PriceListEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.PriceListEditorControl, DykBits.Crm.Dictionaries" ParentId="1965" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.240" CreatedBy="2" Modified="2015-01-26T00:58:38.640" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1968" State="1" FileAs="Общие" Key="CalculationStatementEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CalculationStatementEditorControl, DykBits.Crm.Dictionaries" ParentId="1967" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.267" CreatedBy="2" Modified="2015-03-18T15:38:49.490" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1970" State="1" FileAs="Общие" Key="AccountEventEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountEventEditorControl, DykBits.Crm.Dictionaries" ParentId="1969" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.293" CreatedBy="2" Modified="2014-11-28T20:48:17.620" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1972" State="1" FileAs="Общие" Key="DocumentEmployeeAccessRightEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentEmployeeAccessRightEditorControl, DykBits.Crm.Dictionaries" ParentId="1971" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.320" CreatedBy="2" Modified="2014-11-28T20:48:09.997" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1974" State="1" FileAs="Общие" Key="MoneyOperationEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationEditorControl, DykBits.Crm.Dictionaries" ParentId="1973" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.347" CreatedBy="2" Modified="2015-01-26T00:54:38.870" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1976" State="1" FileAs="Общие" Key="PurchaseInvoiceEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.PurchaseInvoiceEditorControl, DykBits.Crm.Dictionaries" ParentId="1975" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.373" CreatedBy="2" Modified="2015-01-26T00:26:14.270" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1977" State="1" FileAs="Платежи" Key="MoneyOperationView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1975" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.387" CreatedBy="2" Modified="2015-01-26T00:26:25.693" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1979" State="1" FileAs="Общие" Key="SalesInvoiceEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SalesInvoiceEditorControl, DykBits.Crm.Dictionaries" ParentId="1978" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.413" CreatedBy="2" Modified="2015-01-26T00:28:28.837" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1980" State="1" FileAs="Платежи" Key="MoneyOperationView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.CashFlow.MoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1978" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABISURBVDhPY/Sq3fifgQLABKXJBhQbwFBUVPQfHWzevBnKQgBsYiC9A+8FRpAzHB0doVzSwOHDh0d8GOzfv3/YhAGUPRCAgQEA0+i/lXsbjzkAAAAASUVORK5CYII=" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB5SURBVFhH7dTBCYAwDAXQ6EpdwosrSXGlXFyiM1UaQi5F9GK/4H8XUxB+oJ8KoU3+lXU/qo9D6LZY9mwnIC4AXyDknOsdVfXp2pN/WpbH8grwC8RD1O4lpeSnd5VSWl5kG5YQhSUMLCEKSxhYQpRvldDHIboS0k+JnFFByG3ynhi+AAAAAElFTkSuQmCC" NodeType="3" Created="2014-11-26T16:43:05.427" CreatedBy="2" Modified="2015-01-26T00:28:40.720" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1982" State="1" FileAs="Общие" Key="PurchaseOrderEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.Inventory.PurchaseOrderEditorControl, DykBits.Crm.Dictionaries" ParentId="1981" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.453" CreatedBy="2" Modified="2015-04-06T16:55:47.903" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1984" State="1" FileAs="Общие" Key="ProjectTaskStatusEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProjectTaskStatusEditorControl, DykBits.Crm.Dictionaries" ParentId="1983" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.480" CreatedBy="2" Modified="2014-11-28T20:47:05.397" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1986" State="1" FileAs="Общие" Key="AccountEventTemplateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccountEventTemplateEditorControl, DykBits.Crm.Dictionaries" ParentId="1985" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.507" CreatedBy="2" Modified="2014-11-28T20:46:58.467" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1988" State="1" FileAs="Общие" Key="TradeMarkEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.TradeMarkEditorControl, DykBits.Crm.Dictionaries" ParentId="1987" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.533" CreatedBy="2" Modified="2014-11-28T20:46:51.230" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1990" State="1" FileAs="Общие" Key="MarketingProgramTypeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.MarketingProgramTypeEditorControl, DykBits.Crm.Dictionaries" ParentId="1989" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.560" CreatedBy="2" Modified="2014-11-28T20:46:43.290" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1992" State="1" FileAs="Общие" Key="ServiceRequestTypeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ServiceRequestTypeEditorControl, DykBits.Crm.Dictionaries" ParentId="1991" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.587" CreatedBy="2" Modified="2014-11-28T20:46:35.797" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1994" State="1" FileAs="Общие" Key="DocumentNumberingRuleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.DocumentNumberingRuleEditorControl, DykBits.Crm.Dictionaries" ParentId="1993" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.613" CreatedBy="2" Modified="2014-11-28T20:46:07.243" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1996" State="1" FileAs="Общие" Key="ItemColorEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ItemColorEditorControl, DykBits.Crm.Dictionaries" ParentId="1995" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.640" CreatedBy="2" Modified="2014-11-28T20:45:59.587" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1998" State="1" FileAs="Общие" Key="UnitOfMeasureClassEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.UnitOfMeasureClassEditorControl, DykBits.Crm.Dictionaries" ParentId="1997" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.670" CreatedBy="2" Modified="2014-11-28T20:45:53.403" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2000" State="1" FileAs="Общие" Key="UnitOfMeasureEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.UnitOfMeasureEditorControl, DykBits.Crm.Dictionaries" ParentId="1999" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.693" CreatedBy="2" Modified="2014-11-28T20:45:46.597" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2002" State="1" FileAs="Общие" Key="CostCenterEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CostCenterEditorControl, DykBits.Crm.Dictionaries" ParentId="2001" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.720" CreatedBy="2" Modified="2014-11-28T20:45:40.157" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2004" State="1" FileAs="Общие" Key="ReasonEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ReasonEditorControl, DykBits.Crm.Dictionaries" ParentId="2003" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.750" CreatedBy="2" Modified="2014-11-28T20:45:33.747" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2006" State="1" FileAs="Общие" Key="ReasonTypeEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ReasonTypeEditorControl, DykBits.Crm.Dictionaries" ParentId="2005" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.777" CreatedBy="2" Modified="2014-11-28T20:45:27.397" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2008" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2007" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.803" CreatedBy="2" Modified="2014-11-28T20:45:20.437" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2010" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2009" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.830" CreatedBy="2" Modified="2014-11-28T20:45:13.933" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2012" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2011" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.857" CreatedBy="2" Modified="2014-11-28T20:45:07.197" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2014" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2013" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.883" CreatedBy="2" Modified="2014-11-28T20:44:59.293" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2016" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2015" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.910" CreatedBy="2" Modified="2014-11-28T20:44:44.727" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2018" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2017" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.937" CreatedBy="2" Modified="2014-11-28T20:41:21.740" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2020" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2019" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.963" CreatedBy="2" Modified="2015-01-26T01:03:04.767" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2022" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2021" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:05.990" CreatedBy="2" Modified="2014-11-28T20:38:07.563" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2024" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2023" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.017" CreatedBy="2" Modified="2014-11-28T20:38:00.603" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2026" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2025" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.040" CreatedBy="2" Modified="2014-11-28T20:37:54.050" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2028" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2027" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.070" CreatedBy="2" Modified="2014-11-28T20:37:47.067" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2030" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2029" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.093" CreatedBy="2" Modified="2014-11-28T20:37:39.883" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2032" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2031" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.120" CreatedBy="2" Modified="2014-11-28T20:37:32.843" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2034" State="1" FileAs="Общие" Key="SimpleEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SimpleEditorControl, DykBits.Crm.Dictionaries" ParentId="2033" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.150" CreatedBy="2" Modified="2014-11-28T20:37:25.667" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2036" State="1" FileAs="Общие" Key="SizeOfServiceRequestEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.SizeOfServiceRequestEditorControl, DykBits.Crm.Dictionaries" ParentId="2035" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABbSURBVDhPY6AUMHrVbvwPZZMFmKA02YBiAxiKior+kwtAelmg5jBs2bIFyoIAHx8fDDFkAJIHAbgBMAF0gE0c2WC4AbgAPleAwWgYUB4GFKdERpApUPZAAAYGAOp60kPe6dIrAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACcSURBVFhH7dRNCoAgEAZQiw7Xwq6U2pV00e0MZRoU+xNBheZtHMEY8WNipLUBVrZsu4WyCr3Ovvfodw3RBZpfAEkpbS2uF7Rt/wITrBFjDFQpzrlfn87cOb+9lBuB1hqqb8LzXUWAf0J3KyEE7N6VRKCUcv2wt5cbQYmuIqApoClAuRGU6CoCmgKaApQbQYkwgugFoKwieQHyU4wdTuorFYG338oAAAAASUVORK5CYII=" NodeType="3" Created="2014-11-26T16:43:06.173" CreatedBy="2" Modified="2014-12-02T16:19:42.573" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2039" State="1" FileAs="Отчеты" Key="FinanceReports" OrdinalPosition="70" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6A5eLK3Rv3Fwcbnrw41/UfHUCW4AUzz10dH/qMDuAEvDzb0optMLAYbgE2CWDxqwKgBIEwdAwYYMDAAAFjyPOyj392yAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADjSURBVFhH7ZIxDoJAAAT5nz+wsvUHJgI+yhdY6JH4CBsTo2BnwAJBMNtsslCxVkwyFXs3VxDNzEzF45gsipCUzyxtx8xDssGR6chP8bLIdvX7fm4HaT7t67L/PQLHpiEP23V/aXULKA3T1NW0DyhOSdpfWF4PSIwz+oAixKv+4z9Ekul+oFqNHSLJqKFLJBk1dIkko4YukWTU0CWSjBq6RJJRQ5dIMmroEklGDV0iyaihSyQZNXSJJKOGLpFk1NAlkowaukSSUUOXSDJq6BJJRg1dIsmooUskGTV0ieTMTEcUfQGixG/rNFkd8gAAAABJRU5ErkJggg==" NodeType="1" Created="2014-12-01T14:50:43.420" CreatedBy="2" Modified="2015-01-26T00:12:59.670" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2040" State="1" FileAs="ДС выданные под отчет" Key="AdvanceItemView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.CashFlow.AdvanceItemGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-12-02T00:28:25.860" CreatedBy="2" Modified="2015-04-05T23:39:48.580" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2044" State="1" FileAs="Общие" Key="AdvanceReportEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CashFlow.AdvanceReportEditorControl, DykBits.Crm.Dictionaries" ParentId="2043" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2014-12-02T16:23:50.510" CreatedBy="2" Modified="2015-01-26T00:21:44.730" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2045" State="1" FileAs="Отчет о прибылях и убытках" Key="ProfitLossView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.Reports.ProfitLossGridControl, DykBits.Crm.Dictionaries" ParentId="2039" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-12-04T14:51:03.993" CreatedBy="2" Modified="2015-01-26T00:13:43.970" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2046" State="1" FileAs="Отчет о движении денежных средств" Key="CashFlowView" OrdinalPosition="50" ViewControlTypeName="DykBits.Crm.UI.Reports.CashFlowGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-12-04T14:52:03.970" CreatedBy="2" Modified="2015-04-05T23:39:14.900" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2047" State="1" FileAs="Баланс" Key="BalanceView" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.Reports.BalanceGridControl, DykBits.Crm.Dictionaries" ParentId="2039" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-12-04T14:53:08.503" CreatedBy="2" Modified="2015-01-26T00:14:05.673" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2048" State="1" FileAs="Движение складских запасов" Key="ConsolidatedInventoryView" OrdinalPosition="70" ViewControlTypeName="DykBits.Crm.UI.Reports.ConsolidatedInventoryGridControl, DykBits.Crm.Dictionaries" ParentId="1674" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2014-12-09T16:05:53.620" CreatedBy="2" Modified="2015-04-06T17:00:49.823" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3049" State="1" FileAs="Общие" Key="CreditIssueReturnEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CashFlow.CreditIssueReturnEditorControl, DykBits.Crm.Dictionaries" ParentId="3048" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2014-12-17T14:27:42.793" CreatedBy="2" Modified="2015-01-26T01:02:15.540" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3050" State="1" FileAs="Расходные накладные" Key="SalesOrder" OrdinalPosition="240" ViewControlTypeName="DykBits.Crm.UI.Inventory.SalesOrderGridControl, DykBits.Crm.Dictionaries" ParentId="1761" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2014-12-22T23:37:24.653" CreatedBy="2" Modified="2015-01-29T14:44:15.447" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="ApplicationUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3051" State="1" FileAs="Расходные накладные" Key="SalesOrders" OrdinalPosition="45" ViewControlTypeName="DykBits.Crm.UI.Inventory.SalesOrderGridControl, DykBits.Crm.Dictionaries" ParentId="1896" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-02-09T15:56:59.407" CreatedBy="2" Modified="2015-02-09T16:40:28.767" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3052" State="1" FileAs="Справочники" Key="FinanceDictionaries" OrdinalPosition="80" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6A5eLK3Rv3Fwcbnrw41/UfHUCW4AUzz10dH/qMDuAEvDzb0optMLAYbgE2CWDxqwKgBIEwdAwYYMDAAAFjyPOyj392yAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADjSURBVFhH7ZIxDoJAAAT5nz+wsvUHJgI+yhdY6JH4CBsTo2BnwAJBMNtsslCxVkwyFXs3VxDNzEzF45gsipCUzyxtx8xDssGR6chP8bLIdvX7fm4HaT7t67L/PQLHpiEP23V/aXULKA3T1NW0DyhOSdpfWF4PSIwz+oAixKv+4z9Ekul+oFqNHSLJqKFLJBk1dIkko4YukWTU0CWSjBq6RJJRQ5dIMmroEklGDV0iyaihSyQZNXSJJKOGLpFk1NAlkowaukSSUUOXSDJq6BJJRg1dIsmooUskGTV0ieTMTEcUfQGixG/rNFkd8gAAAABJRU5ErkJggg==" NodeType="1" Created="2015-03-04T02:30:16.860" CreatedBy="2" Modified="2015-03-04T02:30:16.860" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3053" State="1" FileAs="Ставки конвертации" Key="ExtraCostRateView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ExtraCostRateGridControl, DykBits.Crm.Dictionaries" ParentId="3052" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-04T02:32:14.070" CreatedBy="2" Modified="2015-03-04T02:32:14.070" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3054" State="1" FileAs="Ставки налогов" Key="TaxRateView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.TaxRateGridControl, DykBits.Crm.Dictionaries" ParentId="3052" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-04T02:34:38.263" CreatedBy="2" Modified="2015-03-04T02:34:38.263" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2042" State="1" FileAs="Общие" Key="CreditReturnEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.CashFlow.CreditReturnEditorControl, DykBits.Crm.Dictionaries" ParentId="2041" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2014-12-02T16:19:39.847" CreatedBy="2" Modified="2015-01-26T01:02:36.087" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3056" State="1" FileAs="Общие" Key="ExtraCostRateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ExtraCostRateEditorControl, DykBits.Crm.Dictionaries" ParentId="3055" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2015-03-04T02:39:40.873" CreatedBy="2" Modified="2015-03-04T02:39:40.873" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3058" State="1" FileAs="Общие" Key="TaxRateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.TaxRateEditorControl, DykBits.Crm.Dictionaries" ParentId="3057" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2015-03-04T02:43:15.600" CreatedBy="2" Modified="2015-03-04T02:43:15.600" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3060" State="1" FileAs="Общие" Key="VATRateEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.VATRateEditorControl, DykBits.Crm.Dictionaries" ParentId="3059" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2015-03-04T03:03:46.643" CreatedBy="2" Modified="2015-03-04T03:03:46.643" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3061" State="1" FileAs="Себестоимость услуг" Key="ProductCost" DefaultViewId="3065" OrdinalPosition="35" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABnSURBVDhPzY5BCsAwCAR9X5/jvY8qPjDtioIYAx5CycAmZdkMpXO57md0YvOZalzF5j1KQVVWgWB8iAguhZl/FuBxjApwONnu6HD1B1sEKHPQx0CQO+1xOHjoxG8drtgi6MTmx0H0AgfZo3hwdDZzAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAC0SURBVFhH7ZFRCoMwEERzQS+TI/RK+entLAOTpcLEuGssWvJgUOPyHJM0mURYXu91VKj0oUTRUOlDiaKh0ocSRUOlj5zzqiil8G5Lax0eKsdCv9EtoLYmGvjwwSO5rAB/0MDHFP9b4Hub92IFcKPAkKK1XoV8NHrz9yiAobOpQvVOZVNAgSFFa70K+Wj05ucRzCMYfgS4Ho0VUECqaK2b0MstCkB6Ns/eAcVPC4wKlZOnkNIHwlesZ4ucVg0AAAAASUVORK5CYII=" NodeType="2" Created="2015-03-15T15:04:40.813" CreatedBy="2" Modified="2015-03-30T15:20:31.453" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3063" State="1" FileAs="Общие" Key="ProductCostStatementEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProductCostStatementEditorControl, DykBits.Crm.Dictionaries" ParentId="3062" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2015-03-15T15:08:50.017" CreatedBy="2" Modified="2015-03-30T14:49:24.523" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3064" State="1" FileAs="Мои ПРС" Key="MyBudgets" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.BudgetGridControl, DykBits.Crm.Dictionaries" Parameter="MyBudgets" ParentId="1705" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-15T15:12:30.660" CreatedBy="2" Modified="2015-03-16T03:16:11.963" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3065" State="1" FileAs="Ведомости учета себестоимости" Key="ProductCostStatementView" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.ProductCostStatementGridControl, DykBits.Crm.Dictionaries" ParentId="3061" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-30T15:06:08.557" CreatedBy="2" Modified="2015-03-30T15:06:08.557" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3066" State="1" FileAs="Себестоимость услуг" Key="ServiceCostView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ServiceCostGridControl, DykBits.Crm.Dictionaries" Parameter="ServiceCost" ParentId="3061" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-30T15:08:27.667" CreatedBy="2" Modified="2015-03-30T15:20:19.150" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3067" State="1" FileAs="Цены товаров и услуг" Key="ProductPrice" OrdinalPosition="25" ParentId="1704" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABnSURBVDhPzY5BCsAwCAR9X5/jvY8qPjDtioIYAx5CycAmZdkMpXO57md0YvOZalzF5j1KQVVWgWB8iAguhZl/FuBxjApwONnu6HD1B1sEKHPQx0CQO+1xOHjoxG8drtgi6MTmx0H0AgfZo3hwdDZzAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAC0SURBVFhH7ZFRCoMwEERzQS+TI/RK+entLAOTpcLEuGssWvJgUOPyHJM0mURYXu91VKj0oUTRUOlDiaKh0ocSRUOlj5zzqiil8G5Lax0eKsdCv9EtoLYmGvjwwSO5rAB/0MDHFP9b4Hub92IFcKPAkKK1XoV8NHrz9yiAobOpQvVOZVNAgSFFa70K+Wj05ucRzCMYfgS4Ho0VUECqaK2b0MstCkB6Ns/eAcVPC4wKlZOnkNIHwlesZ4ucVg0AAAAASUVORK5CYII=" NodeType="2" Created="2015-03-30T15:53:21.023" CreatedBy="2" Modified="2015-03-30T15:54:04.473" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3068" State="1" FileAs="Цены товаров и услуг" Key="ProductPriceView" OrdinalPosition="20" ViewControlTypeName="DykBits.Crm.UI.ProductPriceGridControl, DykBits.Crm.Dictionaries" Parameter="ProductPrice" ParentId="3067" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-03-30T15:56:25.520" CreatedBy="2" Modified="2015-03-30T15:56:25.520" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3069" State="1" FileAs="Документы" Key="Documents" OrdinalPosition="10" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABnSURBVDhPzY5BCsAwCAR9X5/jvY8qPjDtioIYAx5CycAmZdkMpXO57md0YvOZalzF5j1KQVVWgWB8iAguhZl/FuBxjApwONnu6HD1B1sEKHPQx0CQO+1xOHjoxG8drtgi6MTmx0H0AgfZo3hwdDZzAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAC0SURBVFhH7ZFRCoMwEERzQS+TI/RK+entLAOTpcLEuGssWvJgUOPyHJM0mURYXu91VKj0oUTRUOlDiaKh0ocSRUOlj5zzqiil8G5Lax0eKsdCv9EtoLYmGvjwwSO5rAB/0MDHFP9b4Hub92IFcKPAkKK1XoV8NHrz9yiAobOpQvVOZVNAgSFFa70K+Wj05ucRzCMYfgS4Ho0VUECqaK2b0MstCkB6Ns/eAcVPC4wKlZOnkNIHwlesZ4ucVg0AAAAASUVORK5CYII=" NodeType="2" Created="2015-04-06T07:15:12.303" CreatedBy="2" Modified="2015-04-06T07:16:34.900" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3070" State="1" FileAs="Роли и пользователи" Key="Security" OrdinalPosition="20" ParentId="1746" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABnSURBVDhPzY5BCsAwCAR9X5/jvY8qPjDtioIYAx5CycAmZdkMpXO57md0YvOZalzF5j1KQVVWgWB8iAguhZl/FuBxjApwONnu6HD1B1sEKHPQx0CQO+1xOHjoxG8drtgi6MTmx0H0AgfZo3hwdDZzAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAC0SURBVFhH7ZFRCoMwEERzQS+TI/RK+entLAOTpcLEuGssWvJgUOPyHJM0mURYXu91VKj0oUTRUOlDiaKh0ocSRUOlj5zzqiil8G5Lax0eKsdCv9EtoLYmGvjwwSO5rAB/0MDHFP9b4Hub92IFcKPAkKK1XoV8NHrz9yiAobOpQvVOZVNAgSFFa70K+Wj05ucRzCMYfgS4Ho0VUECqaK2b0MstCkB6Ns/eAcVPC4wKlZOnkNIHwlesZ4ucVg0AAAAASUVORK5CYII=" NodeType="2" Created="2015-04-06T07:18:25.657" CreatedBy="2" Modified="2015-04-06T07:20:17.280" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3072" State="1" FileAs="Начисления по контрагентам" Key="InvoiceByContragentView" OrdinalPosition="30" ViewControlTypeName="DykBits.Crm.UI.Reports.InvoiceByContragentGridControl, DykBits.Crm.Dictionaries" ParentId="1714" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2015-04-11T12:35:56.617" CreatedBy="2" Modified="2015-04-12T15:44:22.023" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3073" State="1" FileAs="Права" Key="AccessRight" OrdinalPosition="15" ViewControlTypeName="DykBits.Crm.UI.AccessRightGridControl, DykBits.Crm.Dictionaries" ParentId="3070" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAA9SURBVDhPY/Cq3fifEjwIDCgqKvqPDjZv3gxlIQA2MZDeQWIASJIcXFZWNuLDgHouQAf0N4ASzEAZYGAAAAUqC8geJ6HgAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAB4SURBVFhH7ZBBCsAwCAT9YP8U+iUv/V2CsODFYi8rQh0YyGHDLsrQhut+dqWodaIQU9Q6UYgpap0oxBS1ThRiilpnrbUzVBWvd75krAu1zgxoMcA+V9j3AhkzgD7APlfY9wIZM4A+wD5X2PcCGTOAPqBS1A6/R+QAO1BU3kPe9z8AAAAASUVORK5CYII=" NodeType="3" Created="2015-04-11T20:51:15.450" CreatedBy="2" Modified="2015-04-11T20:51:15.450" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3075" State="1" FileAs="Общие" Key="AccessRightEditor" OrdinalPosition="10" ViewControlTypeName="DykBits.Crm.UI.AccessRightEditorControl, DykBits.Crm.Dictionaries" ParentId="3074" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="3" Created="2015-04-11T20:55:30.050" CreatedBy="2" Modified="2015-04-11T20:55:30.050" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3076" State="1" FileAs="Оплата счетов" Key="InvoicePaymentByContragentView" OrdinalPosition="40" ViewControlTypeName="DykBits.Crm.UI.Reports.InvoicePaymentByContragentGridControl, DykBits.Crm.Dictionaries" ParentId="1714" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2015-04-12T14:36:59.963" CreatedBy="2" Modified="2015-04-12T15:44:48.830" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3078" State="1" FileAs="Займы" Key="CreditMoneyOperation" OrdinalPosition="60" ViewControlTypeName="DykBits.Crm.UI.Reports.CreditMoneyOperationGridControl, DykBits.Crm.Dictionaries" ParentId="1709" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAADpSURBVDhPY0hb2GOTvrj/dsaSCf8ZgABEE4tB6hmAmu8hCyArIITBBqALIPMJYdoaAPTagbRFfWnpC3rNUhZ1K6Ys6DFOX9SbDBQ/jKwepwHx87skwArQQNLifnVk9Xhc0HcMaGMOOJYW9EqnLuy1T1vcXwR0wSVk9bgNWNTjmr6obyMsloD0QxA/bXGfN7J6fC5Ykbao1yNtYYccSBxEgzQTHQZAA0KgLgAnMiD9LX1R/xaiXQD07y6QC0Lr69lA4qGhocxQFxxAVo/TAGLwIDEA6Kd7wBTXCOaQA6DZ+SE2GwhhBgYGBgBZFP5rJEiwsAAAAABJRU5ErkJggg==" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIOSURBVFhH7VSxSgNBEM03CIKtIFhZCVaCIAiClZWVlSBYWCR3J36AYGVhklsRFSHmVj/AShCEgCAEBCsrq4CQShCsBJ0ZdmEZ5iaRDVZ58Mjt233zbnfnUhmDI7WN9b3rkx9P1MJxLClEQ2ZNhxvCcSwpRAO8wAc3hONYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGycA1TuibXmbzw6ww21mRLyWFma8VzUUaW3MAfPNrKURDWNgbuMaZtOrTZC5B9exoAl7iG9c6qRy8uKRxQvFOWuS1alFfSC+bU+jBUDyJtDA7MP8E/MK1OKeCF5c0Tjx2CDgHvoR6avPX1JobN99HjUI0hAW8gWuccNe3STvfqrYbc1TEIbsys1k738B5eIFPXOumysGLS9ogQlgXdn0Puz+FK9ivtpozIzkBKDJUt6OH9UAHGN8Df+l2pO8Beklr3n09Fd7sGWq4k2G6HfXdi+NJ1LO22YQTugvrqfALQ4N/HtTtiTXLMEd3XUYK0SAZ/DMUf8adyt0OOw3uuozOUg7J4J9rtrGCnQ0hXWAPNfjt4xhOoZXYfA3Hfr1ECtEgGfwzFH/BHqA7l3vgMfRKRI8KycC1GFKIBsnAtRhSiAbJwLUYUogGycC1GFKIBsnAtRhSiAbJwLUYUogGXATf+oMb/j/gW+7hX6ob/j9S21zlxzZKupgxHCqVX3kp3ukbVSTlAAAAAElFTkSuQmCC" NodeType="3" Created="2015-06-07T22:39:48.137" CreatedBy="2" Modified="2015-06-07T22:39:48.137" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1971" State="1" FileAs="Право доступа к документу" Key="DocumentEmployeeAccessRight" OrdinalPosition="710" ClassName="DocumentEmployeeAccessRight" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.307" CreatedBy="2" Modified="2014-11-26T16:43:05.307" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2035" State="1" FileAs="Размер заказа" Key="SizeOfServiceRequest" OrdinalPosition="1020" ClassName="SizeOfServiceRequest" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.160" CreatedBy="2" Modified="2014-11-26T16:43:06.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1804" State="1" FileAs="Роль" Key="ApplicationRole" OrdinalPosition="110" ClassName="ApplicationRole" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.053" CreatedBy="2" Modified="2014-11-26T16:43:03.053" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1878" State="1" FileAs="Акт списания" Key="WriteoffStatement" OrdinalPosition="440" ClassName="WriteoffStatement" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.050" CreatedBy="2" Modified="2015-06-25T11:57:08.290" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1882" State="1" FileAs="Инвентаризационная ведомость" Key="InventoryStatement" OrdinalPosition="460" ClassName="InventoryStatement" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.103" CreatedBy="2" Modified="2015-01-26T00:27:19.753" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1965" State="1" FileAs="Прайс-лист" Key="PriceList" OrdinalPosition="680" ClassName="PriceList" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.227" CreatedBy="2" Modified="2015-01-26T00:58:26.307" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1978" State="1" FileAs="Исходящий счет" Key="SalesInvoice" OrdinalPosition="740" ClassName="SalesInvoice" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.400" CreatedBy="2" Modified="2015-01-26T00:28:16.440" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1975" State="1" FileAs="Входящий счет" Key="PurchaseInvoice" OrdinalPosition="730" ClassName="PurchaseInvoice" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.360" CreatedBy="2" Modified="2015-01-26T00:26:01.080" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1953" State="1" FileAs="Роль участника проекта" Key="ProjectMemberRole" OrdinalPosition="640" ClassName="ProjectMemberRole" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.067" CreatedBy="2" Modified="2014-11-26T16:43:05.067" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1946" State="1" FileAs="Участник проекта" Key="ProjectMember" OrdinalPosition="610" ClassName="ProjectMember" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.973" CreatedBy="2" Modified="2015-03-24T14:40:50.040" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1944" State="1" FileAs="Задача" Key="ProjectTask" OrdinalPosition="600" ClassName="ProjectTask" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.947" CreatedBy="2" Modified="2014-11-26T16:43:04.947" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1991" State="1" FileAs="Форма обслуживания" Key="ServiceRequestType" OrdinalPosition="800" ClassName="ServiceRequestType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.573" CreatedBy="2" Modified="2014-11-26T16:43:05.573" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1955" State="1" FileAs="Заказ покупателя" Key="ServiceRequest" OrdinalPosition="650" ClassName="ServiceRequest" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.093" CreatedBy="2" Modified="2015-03-23T17:33:41.010" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1871" State="1" FileAs="Шаблон ПРС" Key="BudgetTemplate" OrdinalPosition="410" ClassName="BudgetTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.953" CreatedBy="2" Modified="2015-01-26T01:05:09.117" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1960" State="1" FileAs="Банковский счет" Key="BankAccount" OrdinalPosition="660" ClassName="BankAccount" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.160" CreatedBy="2" Modified="2015-01-26T00:23:06.630" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1993" State="1" FileAs="Номер документа" Key="DocumentNumberingRule" OrdinalPosition="810" ClassName="DocumentNumberingRule" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.600" CreatedBy="2" Modified="2014-11-26T16:43:05.600" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1981" State="1" FileAs="Приходная накладная" Key="PurchaseOrder" OrdinalPosition="750" ClassName="PurchaseOrder" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.440" CreatedBy="2" Modified="2015-04-06T16:55:39.080" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1874" State="1" FileAs="Расходная накладная" Key="SalesOrder" OrdinalPosition="420" ClassName="SalesOrder" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.993" CreatedBy="2" Modified="2015-04-06T16:58:13.407" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="Storekeeper" />
      <ApplicationRole Code="ChiefStorekeeper" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1962" State="1" FileAs="Договор" Key="Contract" OrdinalPosition="670" ClassName="Contract" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.187" CreatedBy="2" Modified="2014-11-26T16:43:05.187" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1904" State="1" FileAs="Контрагент" Key="Account" OrdinalPosition="530" ClassName="Account" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.407" CreatedBy="2" Modified="2015-01-26T00:51:42.207" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1989" State="1" FileAs="Типы маркетинговых програм" Key="MarketingProgramType" OrdinalPosition="790" ClassName="MarketingProgramType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.547" CreatedBy="2" Modified="2014-11-26T16:43:05.547" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2019" State="1" FileAs="Склады" Key="StoragePlace" OrdinalPosition="940" ClassName="StoragePlace" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.950" CreatedBy="2" Modified="2015-01-26T01:02:52.560" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2021" State="1" FileAs="Страна" Key="Country" OrdinalPosition="950" ClassName="Country" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.977" CreatedBy="2" Modified="2014-11-26T16:43:05.977" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1995" State="1" FileAs="Цвет" Key="ItemColor" OrdinalPosition="820" ClassName="ItemColor" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.630" CreatedBy="2" Modified="2014-11-26T16:43:05.630" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2025" State="1" FileAs="Тип контрагента" Key="AccountType" OrdinalPosition="970" ClassName="AccountType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.030" CreatedBy="2" Modified="2014-11-26T16:43:06.030" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1821" State="1" FileAs="Категория номенклатуры" Key="ProductCategory" OrdinalPosition="180" ClassName="ProductCategory" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.283" CreatedBy="2" Modified="2014-11-26T16:43:03.283" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1824" State="1" FileAs="Подкатегория номенклатуры" Key="ProductSubcategory" OrdinalPosition="190" ClassName="ProductSubcategory" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.323" CreatedBy="2" Modified="2014-11-26T16:43:03.323" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1816" State="1" FileAs="Базовая номенклатура" Key="AbstractProduct" OrdinalPosition="160" ClassName="AbstractProduct" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.213" CreatedBy="2" Modified="2015-01-26T00:22:22.947" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1819" State="1" FileAs="Номенклатура" Key="Product" OrdinalPosition="170" ClassName="Product" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.257" CreatedBy="2" Modified="2015-01-26T00:53:57.600" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1999" State="1" FileAs="Единица измерения" Key="UnitOfMeasure" OrdinalPosition="840" ClassName="UnitOfMeasure" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.680" CreatedBy="2" Modified="2014-11-26T16:43:05.680" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1997" State="1" FileAs="Тип единицы измерения" Key="UnitOfMeasureClass" OrdinalPosition="830" ClassName="UnitOfMeasureClass" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.653" CreatedBy="2" Modified="2014-11-26T16:43:05.653" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2001" State="1" FileAs="Центр финансовой ответственности" Key="CostCenter" OrdinalPosition="850" ClassName="CostCenter" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.710" CreatedBy="2" Modified="2014-11-26T16:43:05.710" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1928" State="1" FileAs="Контакт" Key="Contact" OrdinalPosition="570" ClassName="Contact" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.733" CreatedBy="2" Modified="2014-11-26T16:43:04.733" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1920" State="1" FileAs="Подразделение" Key="Division" OrdinalPosition="550" ClassName="Division" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.627" CreatedBy="2" Modified="2015-01-26T00:56:30.753" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1923" State="1" FileAs="Сотрудник" Key="Employee" OrdinalPosition="560" ClassName="Employee" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.667" CreatedBy="2" Modified="2015-01-26T01:03:43.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1865" State="1" FileAs="Статья ПРС" Key="BudgetItem" OrdinalPosition="380" ClassName="BudgetItem" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.873" CreatedBy="2" Modified="2014-11-26T16:43:03.873" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2027" State="1" FileAs="Отрасль" Key="Industry" OrdinalPosition="980" ClassName="Industry" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.053" CreatedBy="2" Modified="2014-11-26T16:43:06.053" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2029" State="1" FileAs="Источник" Key="LeadSource" OrdinalPosition="990" ClassName="LeadSource" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.080" CreatedBy="2" Modified="2014-11-26T16:43:06.080" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1914" State="1" FileAs="Организация" Key="Organization" OrdinalPosition="540" ClassName="Organization" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.547" CreatedBy="2" Modified="2015-01-26T00:54:52.037" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2031" State="1" FileAs="Должность" Key="Position" OrdinalPosition="1000" ClassName="Position" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.110" CreatedBy="2" Modified="2014-11-26T16:43:06.110" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2003" State="1" FileAs="Повод" Key="Reason" OrdinalPosition="860" ClassName="Reason" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.737" CreatedBy="2" Modified="2014-11-26T16:43:05.737" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2005" State="1" FileAs="Тип повода" Key="ReasonType" OrdinalPosition="870" ClassName="ReasonType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.763" CreatedBy="2" Modified="2014-11-26T16:43:05.763" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1940" State="1" FileAs="Проект" Key="Project" OrdinalPosition="590" ClassName="Project" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.893" CreatedBy="2" Modified="2014-11-26T16:43:04.893" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2033" State="1" FileAs="Регион" Key="Region" OrdinalPosition="1010" ClassName="Region" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.133" CreatedBy="2" Modified="2014-11-26T16:43:06.133" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2023" State="1" FileAs="Тип возможности" Key="OpportunityType" OrdinalPosition="960" ClassName="OpportunityType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:06.003" CreatedBy="2" Modified="2014-11-26T16:43:06.003" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1798" State="1" FileAs="Учетная запись" Key="User" OrdinalPosition="80" ClassName="User" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.973" CreatedBy="2" Modified="2014-11-26T16:43:02.973" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2007" State="1" FileAs="Группа контактов" Key="ContactGroup" OrdinalPosition="880" ClassName="ContactGroup" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.790" CreatedBy="2" Modified="2014-11-26T16:43:05.790" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2009" State="1" FileAs="Возможность кейтеринга" Key="CateringType" OrdinalPosition="890" ClassName="CateringType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.817" CreatedBy="2" Modified="2014-11-26T16:43:05.817" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2011" State="1" FileAs="Расположение площадки" Key="VenuePlace" OrdinalPosition="900" ClassName="VenuePlace" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.843" CreatedBy="2" Modified="2014-11-26T16:43:05.843" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2013" State="1" FileAs="Тип площадки" Key="VenueType" OrdinalPosition="910" ClassName="VenueType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.870" CreatedBy="2" Modified="2014-11-26T16:43:05.870" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1932" State="1" FileAs="Площадка" Key="Venue" OrdinalPosition="580" ClassName="Venue" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.787" CreatedBy="2" Modified="2015-01-26T00:56:04.383" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1785" State="1" FileAs="Класс документа" Key="DocumentTypeEntry" OrdinalPosition="30" ClassName="DocumentTypeEntry" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.797" CreatedBy="2" Modified="2014-11-28T03:55:41.440" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1794" State="1" FileAs="Состояние документа" Key="DocumentStateEntry" OrdinalPosition="60" ClassName="DocumentStateEntry" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.920" CreatedBy="2" Modified="2014-11-26T16:43:02.920" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1796" State="1" FileAs="Шаблон перехода" Key="DocumentTransition" OrdinalPosition="70" ClassName="DocumentTransition" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.947" CreatedBy="2" Modified="2014-11-26T16:43:02.947" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2015" State="1" FileAs="Группа контрагентов" Key="AccountGroup" OrdinalPosition="920" ClassName="AccountGroup" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.897" CreatedBy="2" Modified="2014-11-26T16:43:05.897" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2017" State="1" FileAs="Вид деятельности" Key="BusinessActivityType" OrdinalPosition="930" ClassName="BusinessActivityType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.923" CreatedBy="2" Modified="2014-11-26T16:43:05.923" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1987" State="1" FileAs="Торговая марка" Key="TradeMark" OrdinalPosition="780" ClassName="TradeMark" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.520" CreatedBy="2" Modified="2014-11-26T16:43:05.520" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1969" State="1" FileAs="Событие" Key="AccountEvent" OrdinalPosition="700" ClassName="AccountEvent" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.280" CreatedBy="2" Modified="2014-11-26T16:43:05.280" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1985" State="1" FileAs="Шаблон события" Key="AccountEventTemplate" OrdinalPosition="770" ClassName="AccountEventTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.493" CreatedBy="2" Modified="2014-11-26T16:43:05.493" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1896" State="1" FileAs="Бюджет" Key="Budget" OrdinalPosition="510" ClassName="Budget" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.293" CreatedBy="2" Modified="2015-03-16T13:36:15.713" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1862" State="1" FileAs="Раздел ПРС" Key="BudgetItemGroup" OrdinalPosition="370" ClassName="BudgetItemGroup" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.833" CreatedBy="2" Modified="2014-11-26T16:43:03.833" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1828" State="1" FileAs="Продукт питания" Key="MasterMenu" OrdinalPosition="210" ClassName="MasterMenu" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.377" CreatedBy="2" Modified="2015-01-26T01:00:22.770" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1841" State="1" FileAs="Сезон" Key="Season" OrdinalPosition="270" ClassName="Season" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.553" CreatedBy="2" Modified="2014-11-26T16:43:03.553" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1839" State="1" FileAs="Ингредиент" Key="DishIngredient" OrdinalPosition="260" ClassName="DishIngredient" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.523" CreatedBy="2" Modified="2014-11-26T16:43:03.523" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1830" State="1" FileAs="Тип блюда" Key="DishType" OrdinalPosition="220" ClassName="DishType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.400" CreatedBy="2" Modified="2014-11-26T16:43:03.400" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1833" State="1" FileAs="Подтип блюда" Key="DishSubtype" OrdinalPosition="230" ClassName="DishSubtype" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.443" CreatedBy="2" Modified="2014-11-26T16:43:03.443" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1847" State="1" FileAs="Категория блюда" Key="DishCourse" OrdinalPosition="300" ClassName="DishCourse" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.633" CreatedBy="2" Modified="2014-11-26T16:43:03.633" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1845" State="1" FileAs="Повод" Key="DishOccasion" OrdinalPosition="290" ClassName="DishOccasion" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.607" CreatedBy="2" Modified="2014-11-26T16:43:03.607" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1849" State="1" FileAs="Диета" Key="DishDiet" OrdinalPosition="310" ClassName="DishDiet" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.660" CreatedBy="2" Modified="2014-11-26T16:43:03.660" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1835" State="1" FileAs="Кухня" Key="DishWorld" OrdinalPosition="240" ClassName="DishWorld" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.470" CreatedBy="2" Modified="2014-11-26T16:43:03.470" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1837" State="1" FileAs="Метод приготовления" Key="DishCookingMethod" OrdinalPosition="250" ClassName="DishCookingMethod" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.497" CreatedBy="2" Modified="2014-11-26T16:43:03.497" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1843" State="1" FileAs="Способ подачи" Key="DishServing" OrdinalPosition="280" ClassName="DishServing" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.580" CreatedBy="2" Modified="2014-11-26T16:43:03.580" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1851" State="1" FileAs="Напиток" Key="Beverage" OrdinalPosition="320" ClassName="Beverage" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.687" CreatedBy="2" Modified="2015-01-26T00:53:03.860" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1853" State="1" FileAs="Тип напитка" Key="BeverageType" OrdinalPosition="330" ClassName="BeverageType" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.713" CreatedBy="2" Modified="2014-11-26T16:43:03.713" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1856" State="1" FileAs="Подтип напитка" Key="BeverageSubtype" OrdinalPosition="340" ClassName="BeverageSubtype" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.753" CreatedBy="2" Modified="2014-11-26T16:43:03.753" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1858" State="1" FileAs="Тара" Key="BeveragePack" OrdinalPosition="350" ClassName="BeveragePack" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.780" CreatedBy="2" Modified="2014-11-26T16:43:03.780" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1860" State="1" FileAs="Специальное предложение" Key="BeverageMisc" OrdinalPosition="360" ClassName="BeverageMisc" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.807" CreatedBy="2" Modified="2014-11-26T16:43:03.807" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1867" State="1" FileAs="Связь статей ПРС" Key="BudgetItemLink" OrdinalPosition="390" ClassName="BudgetItemLink" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.900" CreatedBy="2" Modified="2014-11-26T16:43:03.900" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1826" State="1" FileAs="Наценка" Key="PriceMargin" OrdinalPosition="200" ClassName="PriceMargin" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.350" CreatedBy="2" Modified="2015-01-26T00:53:29.573" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="ProductManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1951" State="1" FileAs="Шаблон задачи" Key="ProjectTaskTemplate" OrdinalPosition="630" ClassName="ProjectTaskTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.040" CreatedBy="2" Modified="2014-11-26T16:43:05.040" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1948" State="1" FileAs="Шаблон проекта" Key="ProjectTemplate" OrdinalPosition="620" ClassName="ProjectTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05" CreatedBy="2" Modified="2014-11-26T16:43:05" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1792" State="1" FileAs="Запрос к базе данных" Key="DataQuery" OrdinalPosition="50" ClassName="DataQuery" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.890" CreatedBy="2" Modified="2014-11-26T16:43:02.890" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1983" State="1" FileAs="Статус задачи" Key="ProjectTaskStatus" OrdinalPosition="760" ClassName="ProjectTaskStatus" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.467" CreatedBy="2" Modified="2014-11-26T16:43:05.467" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1810" State="1" FileAs="Ошибка" Key="ErrorInformation" OrdinalPosition="130" ClassName="ErrorInformation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.133" CreatedBy="2" Modified="2014-11-26T16:43:03.133" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1902" State="1" FileAs="Смета" Key="EstimatesDocument" OrdinalPosition="520" ClassName="EstimatesDocument" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.380" CreatedBy="2" Modified="2015-01-26T01:03:15.580" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="AccountManager" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1884" State="1" FileAs="Шаблон сметы" Key="EstimatesTemplate" OrdinalPosition="470" ClassName="EstimatesTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.130" CreatedBy="2" Modified="2015-01-26T01:05:46.593" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="ReadOnlyUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3059" State="1" FileAs="Ставка НДС" Key="VATRate" OrdinalPosition="1070" ClassName="VATRate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2015-03-04T03:02:43.863" CreatedBy="2" Modified="2015-03-04T03:02:43.863" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3055" State="1" FileAs="Ставка конвертации" Key="ExtraCostRate" OrdinalPosition="1050" ClassName="ExtraCostRate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2015-03-04T02:38:09.967" CreatedBy="2" Modified="2015-03-04T02:41:18.963" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1790" State="1" FileAs="Отчет" Key="DocumentReport" OrdinalPosition="40" ClassName="DocumentReport" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:02.863" CreatedBy="2" Modified="2014-11-26T16:43:02.863" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1807" State="1" FileAs="Права доступа к документу" Key="DocumentAccessControlList" OrdinalPosition="120" ClassName="DocumentAccessControlList" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.093" CreatedBy="2" Modified="2014-11-26T16:43:03.093" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1869" State="1" FileAs="Шаблон калькуляции" Key="CalculationStatementTemplate" OrdinalPosition="400" ClassName="CalculationStatementTemplate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.927" CreatedBy="2" Modified="2015-01-26T01:04:43.143" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="BudgetTemplateManager" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1967" State="1" FileAs="Калькуляция" Key="CalculationStatement" OrdinalPosition="690" ClassName="CalculationStatement" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.253" CreatedBy="2" Modified="2015-03-18T15:39:29.297" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="SalesManager" />
      <ApplicationRole Code="HeadOfSales" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
      <ApplicationRole Code="EventManager" />
      <ApplicationRole Code="ChiefEventManager" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1812" State="1" FileAs="Сообщение об ошибке" Key="ErrorMessage" OrdinalPosition="140" ClassName="ErrorMessage" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.160" CreatedBy="2" Modified="2014-11-26T16:43:03.160" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1880" State="1" FileAs="Акт возврата" Key="ReturnStatement" OrdinalPosition="450" ClassName="ReturnStatement" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.077" CreatedBy="2" Modified="2015-01-26T00:21:15.667" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1894" State="1" FileAs="Расчетная ведомость" Key="Payroll" OrdinalPosition="500" ClassName="Payroll" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.267" CreatedBy="2" Modified="2015-01-26T01:01:29.040" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3057" State="1" FileAs="Налоговая ставкa" Key="TaxRate" OrdinalPosition="1060" ClassName="TaxRate" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2015-03-04T02:40:43.797" CreatedBy="2" Modified="2015-03-04T02:41:34.373" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1886" State="1" FileAs="Бюджет операционных расходов" Key="OperatingBudget" OrdinalPosition="480" ClassName="OperatingBudget" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.157" CreatedBy="2" Modified="2015-01-26T00:24:41.830" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1892" State="1" FileAs="Калькуляция операционных расходов" Key="OperatingCalculation" OrdinalPosition="490" ClassName="OperatingCalculation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:04.237" CreatedBy="2" Modified="2015-01-26T00:51:09.143" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2043" State="1" FileAs="Авансовый отчет" Key="AdvanceReportWindow" OrdinalPosition="1040" ClassName="MoneyOperation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-12-02T16:21:00.247" CreatedBy="2" Modified="2015-01-26T00:21:04.990" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3048" State="1" FileAs="Расчеты с заемщиком" Key="CreditIssueReturnWindow" OrdinalPosition="1040" ClassName="MoneyOperation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-12-17T14:26:28.960" CreatedBy="2" Modified="2015-01-26T01:02:05.100" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="2041" State="1" FileAs="Расчеты с кредитором" Key="CreditReturnWindow" OrdinalPosition="1030" ClassName="MoneyOperation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-12-02T16:17:02.717" CreatedBy="2" Modified="2015-01-26T01:02:25.557" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1973" State="1" FileAs="Операция с ДС" Key="MoneyOperation" OrdinalPosition="720" ClassName="MoneyOperation" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:05.333" CreatedBy="2" Modified="2015-01-26T00:54:25.113" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="1814" State="1" FileAs="Представление" Key="PresentationNode" OrdinalPosition="150" ClassName="PresentationNode" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABDSURBVDhPY6AYeNVu/E8JHgQGNDQ0/CcXgPSiGLB582asGF0OBrAagA6wicEA9V1AKiDJBdjAcHIBJRiapQYMMDAAAB2qpNWcGzLhAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACVSURBVFhH7ZBBCoAwDAT7Qf9U/FIv/k4JJOSykrSSErUDA0Iju2xZpGHbj3OmHKugo0g5VkFHkXKsgo4i5VgFHUXKsUqt9ZwFZXGskqpAa21IAb2RgqtALz3/fL8AfSOFdywwohezwFNQOVIIL2BhFkDtPXrJv0A0ZgE0r0cv+ReIxiyA5vXoJf8C0dwWmCnHLn5PKRdqhWFW65YxeAAAAABJRU5ErkJggg==" NodeType="1" Created="2014-11-26T16:43:03.187" CreatedBy="2" Modified="2014-11-26T16:43:03.187" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3062" State="1" FileAs="Себестоимость услуг" Key="ProductCostStatement" OrdinalPosition="1080" ClassName="ProductCostStatement" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2015-03-15T15:07:18.397" CreatedBy="2" Modified="2015-03-30T14:49:16.163" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SuperUser" />
      <ApplicationRole Code="Accountant" />
      <ApplicationRole Code="ChiefAccountant" />
    </ApplicationRoles>
  </PresentationNode>
  <PresentationNode Id="3074" State="1" FileAs="Право" Key="AccessRight" OrdinalPosition="0" ClassName="AccessRight" SmallImageData="iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAABeSURBVDhPY6AYeNVu/E8JHgQGFBUV/ScXgPTCDdi8eTMKxiaGjEEAxQBsAKYQHZBkAC4MAgQNIARQDMBmA7oYMgYBgi6AKUQHJBmAC4MAQQMIAeoZQAmG5klyAQMDAAhF1JOyltTkAAAAAElFTkSuQmCC" LargeImageData="iVBORw0KGgoAAAANSUhEUgAAACAAAAAgCAYAAABzenr0AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACYSURBVFhH7ZBBCsAgDAT9YP8k/ZKX/s5SyBIPKypGEevAnBKyS9xhGa77iTOVWIUtjVRiFbY0UolV2NJIJVZhSyOVWMV7H2fxZUmsslSBEEJWwGYlgckH0oM17FmgVWBSoIf1C7D3QcBmJYHJB9KDNexZoFVgUqCH9Quw90HAZiWByQfSgzXsWaBVYFKgh2yBmUrs4fc49wLwdVP6uPmnBAAAAABJRU5ErkJggg==" NodeType="1" Created="2015-04-11T20:53:20.950" CreatedBy="2" Modified="2015-04-11T21:02:02.410" ModifiedBy="2">
    <ApplicationRoles>
      <ApplicationRole Code="SecurityAdministrator" />
    </ApplicationRoles>
  </PresentationNode>
</ArrayOfPresentationNode>';

update [PresentationNode]
set
	[DefaultViewId] = null,
	[ParentId] = null;

delete [dbo].[PresentationNodeApplicationRole];
delete [dbo].[PresentationNode];
delete [dbo].[DocumentLog] where [DocumentTypeId] = [dbo].[GetDocumentTypeId]('PresentationNode');

set identity_insert [PresentationNode] on;

insert [PresentationNode]
	([Id], [State], [FileAs], [Key], [DefaultViewId], [OrdinalPosition], [ViewControlTypeName], 
	[Parameter], [ParentId], [DocumentTypeId], [SmallImageData], [LargeImageData],
	[NodeType], [Comments], [Created], [CreatedBy], [Modified], [ModifiedBy])
select
	T.c.value('@Id', 'int'),
	T.c.value('@State', 'tinyint'),
	T.c.value('@FileAs', 'nvarchar(256)'),
	coalesce(T.c.value('@Key', 'nvarchar(256)'), T.c.value('@ViewControlTypeName', 'varchar(1024)'), T.c.value('@FileAs', 'nvarchar(256)')),
	null, 
	T.c.value('@OrdinalPosition', 'int'),
	T.c.value('@ViewControlTypeName', 'varchar(1024)'),
	T.c.value('@Parameter', 'nvarchar(256)'),
	null, 
	dbo.GetDocumentTypeId(T.c.value('@ClassName', 'varchar(256)')),
	T.c.value('@SmallImageData', 'varbinary(max)'),
	T.c.value('@LargeImageData', 'varbinary(max)'),
	T.c.value('@NodeType', 'int'),
	T.c.value('@Comments', 'nvarchar(1024)'),
	T.c.value('@Created', 'datetime'),
	T.c.value('@CreatedBy', 'int'),
	T.c.value('@Modified', 'datetime'),
	T.c.value('@ModifiedBy', 'int')
from
	@xml.nodes('ArrayOfPresentationNode/PresentationNode') as T(c);

with [T] ([Id], [DefaultViewId], [ParentId]) as
(
	select
		T.c.value('@Id', 'int'),
		T.c.value('@DefaultViewId', 'int'),
		T.c.value('@ParentId', 'int')
	from
		@xml.nodes('ArrayOfPresentationNode/PresentationNode') as T(c)
)
update [PresentationNode]
set
	[DefaultViewId] = [T].[DefaultViewId],
	[ParentId] = [T].[ParentId]
from
	[PresentationNode] inner join [T]
		on ([PresentationNode].[Id] = [T].[Id]);

set identity_insert [PresentationNode] off;

insert into [dbo].[PresentationNodeApplicationRole]
	([PresentationNodeId], [ApplicationRoleId])
select distinct
	T.c.value('(../../@Id)', 'int'),
	[ApplicationRole].[Id]
from
	@xml.nodes('ArrayOfPresentationNode/PresentationNode/ApplicationRoles/ApplicationRole') as T(c) inner join [ApplicationRole]	
		on (T.c.value('@Code', 'nvarchar(256)') = [ApplicationRole].[Code]);
