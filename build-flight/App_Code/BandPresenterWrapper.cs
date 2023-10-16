using DevExpress.XtraReports.Native.Presenters;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Globalization;


public class BandPresenterWrapper : BandPresenter
{
    readonly BandPresenter presenter;
    readonly CultureInfo culture;

    public BandPresenterWrapper(BandPresenter presenter, CultureInfo culture, XtraReport report)
        : base(report)
    {
        this.presenter = presenter;
        this.culture = culture;
    }

    public override List<XRControl> GetPrintableControls(Band band)
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = culture;
        return presenter.GetPrintableControls(band);
    }
}
