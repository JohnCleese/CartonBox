using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonBox
{
    class CartonCreate
    {
        public Double parameterL { get; set; }
        public Double parameterB { get; set; }
        public Double parameterH { get; set; }
        public Double parameterThick { get; set; } 

        SldWorks swApp;
        ModelDoc2 swModel;
        Feature swFeature;
        bool status;
        string defaultPartTemplate;

        public void CartonCreator()
        {
            swApp = new SldWorks();
            defaultPartTemplate = swApp.GetUserPreferenceStringValue((int)
                swUserPreferenceStringValue_e.swDefaultTemplatePart);
            swApp.NewDocument(defaultPartTemplate, 0, 0, 0);
            swModel = (ModelDoc2)swApp.ActiveDoc;
            swFeature = (Feature)swModel.FeatureByPositionReverse(0);
            swFeature.Name = "RefPlane";
            status = swModel.Extension.SelectByID2("RefPlane", "PLANE", 0, 0, 0, false, 0, null, 0);

            swModel.InsertSketch();

            swModel.SketchManager.CreateCenterLine(0, 0, 0, parameterL, 0, 0);
            swModel.SketchManager.CreateCenterLine(parameterL, 0, 0, parameterL, parameterH, 0);
            swModel.SketchManager.CreateCenterLine(parameterL, parameterH, 0, 0, parameterH, 0);
            swModel.SketchManager.CreateCenterLine(0, parameterH, 0, 0, 0, 0);

            swModel.CreateLine2(0, 0, 0, -parameterB/4, 0, 0);
            swModel.CreateLine2(-parameterB / 4, 0, 0, -parameterB/4, parameterH, 0);
            swModel.CreateLine2(-parameterB / 4, parameterH, 0, 0, parameterH, 0);

            swModel.CreateLine2(0, 0, 0, 0, -parameterB/2, 0);
            swModel.CreateLine2(0, -parameterB/2, 0, parameterL-parameterThick, -parameterB / 2, 0);
            swModel.CreateLine2(parameterL - parameterThick, -parameterB / 2, 0, parameterL-parameterThick, 0, 0);

            swModel.CreateLine2(0, parameterH, 0, 0, parameterH+parameterB/2, 0);
            swModel.CreateLine2(0, parameterH + parameterB / 2, 0, parameterL  -parameterThick, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(parameterL - parameterThick, parameterH + parameterB / 2, 0, parameterL - parameterThick, parameterH, 0);

            swModel.SketchManager.CreateCenterLine(parameterL, 0, 0, parameterL+parameterB, 0, 0);
            swModel.SketchManager.CreateCenterLine(parameterL + parameterB, 0, 0, parameterL + parameterB, parameterH, 0);
            swModel.SketchManager.CreateCenterLine(parameterL + parameterB, parameterH, 0, parameterL, parameterH, 0);

            swModel.CreateLine2(parameterL + parameterThick, 0, 0, parameterL + parameterThick, -parameterB/2, 0);
            swModel.CreateLine2(parameterL + parameterThick, -parameterB / 2, 0, parameterL - parameterThick + parameterB, -parameterB / 2, 0);
            swModel.CreateLine2(parameterL - parameterThick + parameterB, -parameterB / 2, 0, parameterL - parameterThick + parameterB, 0, 0);

            swModel.CreateLine2(parameterL + parameterThick, parameterH, 0, parameterL + parameterThick, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(parameterL + parameterThick, parameterH + parameterB / 2, 0, parameterL - parameterThick + parameterB, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(parameterL - parameterThick + parameterB, parameterH + parameterB / 2, 0, parameterL + parameterB - parameterThick, parameterH, 0);

            swModel.SketchManager.CreateCenterLine(parameterL + parameterB, 0, 0, 2 * parameterL + parameterB, 0, 0);
            swModel.SketchManager.CreateCenterLine(2 * parameterL + parameterB, 0, 0, 2 * parameterL + parameterB, parameterH, 0);
            swModel.SketchManager.CreateCenterLine(2 * parameterL + parameterB, parameterH, 0, parameterL + parameterB, parameterH, 0);

            swModel.CreateLine2(parameterL + parameterB + parameterThick, 0, 0, parameterL + parameterB + parameterThick, -parameterB / 2, 0);
            swModel.CreateLine2(parameterL + parameterB + parameterThick, -parameterB / 2, 0, 2 * parameterL + parameterB - parameterThick, -parameterB / 2, 0);
            swModel.CreateLine2(2 * parameterL + parameterB - parameterThick, -parameterB / 2, 0, 2 * parameterL + parameterB - parameterThick, 0, 0);

            swModel.CreateLine2(parameterL + parameterB + parameterThick, parameterH, 0, parameterL + parameterB + parameterThick, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(parameterL + parameterB + parameterThick, parameterH + parameterB / 2, 0, 2 * parameterL + parameterB - parameterThick, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(2 * parameterL + parameterB - parameterThick, parameterH + parameterB / 2, 0, 2 * parameterL + parameterB - parameterThick, parameterH, 0);

            swModel.SketchManager.CreateCenterLine(2 * parameterL + parameterB, 0, 0, 2 * (parameterB + parameterL), 0, 0);
            swModel.CreateLine2(2 * (parameterB + parameterL), 0, 0, 2 * (parameterB + parameterL), parameterH, 0);
            swModel.SketchManager.CreateCenterLine(2 * (parameterB + parameterL), parameterH, 0, 2 * parameterL + parameterB, parameterH, 0);

            swModel.CreateLine2(2 * parameterL + parameterB + parameterThick, 0, 0, 2 * parameterL + parameterB + parameterThick, -parameterB / 2, 0);
            swModel.CreateLine2(2 * parameterL + parameterB + parameterThick, -parameterB / 2, 0, 2 * (parameterL + parameterB), -parameterB / 2, 0);
            swModel.CreateLine2(2 * (parameterL + parameterB), -parameterB / 2, 0, 2 * (parameterL + parameterB), 0, 0);

            swModel.CreateLine2(2 * parameterL + parameterB + parameterThick, parameterH, 0, 2 * parameterL + parameterB + parameterThick, parameterH + parameterB / 2, 0);
            swModel.CreateLine2(2 * parameterL + parameterB + parameterThick, parameterH + parameterB / 2, 0, 2 * (parameterL + parameterB), parameterH + parameterB / 2, 0);
            swModel.CreateLine2(2 * (parameterL + parameterB), parameterH + parameterB / 2, 0, 2 * (parameterL + parameterB), parameterH, 0);

            swModel.CreateLine2(parameterL - parameterThick, 0, 0, parameterL + parameterThick, 0, 0);
            swModel.CreateLine2(parameterL - parameterThick, parameterH, 0, parameterL + parameterThick, parameterH, 0);

            swModel.CreateLine2(parameterL + parameterB - parameterThick, 0, 0,parameterL + parameterB + parameterThick, 0, 0);
            swModel.CreateLine2(parameterL + parameterB - parameterThick, parameterH, 0,parameterL + parameterB + parameterThick, parameterH, 0);

            swModel.CreateLine2(2 * parameterL + parameterB - parameterThick, 0, 0, 2 * parameterL + parameterB + parameterThick, 0, 0);
            swModel.CreateLine2(2 * parameterL + parameterB - parameterThick, parameterH, 0, 2 * parameterL + parameterB + parameterThick, parameterH, 0);
        }
    }
}
