if (window.parent.location == window.location)
{
    var hostname = window.location.hostname;
    window.location.href = "http://" + hostname + "/Main.aspx";
}