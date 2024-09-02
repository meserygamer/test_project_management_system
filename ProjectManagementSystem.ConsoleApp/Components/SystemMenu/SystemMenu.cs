using ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Infrastructure;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SystemMenu
{
    private Dictionary<Type, BaseMenuPage> _menuPages;
    private BaseMenuPage? _currentPage;

    public SystemMenu(
        User user,
        SystemMenuPagesDTO menuPagesDto,
        Type startPage
        )
    {
        User = user;
        _menuPages = menuPagesDto.MenuPages;
        ChangePage(startPage, null);
    }

    public User User { get; }

    public void ChangePage(Type nextPage, Bundle? storedData)
    {
        _currentPage?.LeavePage();
        if (!_menuPages.TryGetValue(nextPage, out _currentPage))
            throw new ArgumentOutOfRangeException();
        
        _currentPage.User = User;
        _currentPage.SavedData = storedData;
        _currentPage.ParentMenu = this;
    }

    public async Task ChangePageWithOpenAsync(Type nextPage, Bundle? storedData)
    {
        ChangePage(nextPage, storedData);
        await OpenMenuAsync();
    }

    public async Task OpenMenuAsync()
    {
        Console.Clear();
        if(_currentPage is not null) 
            await _currentPage.OpenPageAsync();
    }
}