import {IGeneralResult} from "../../../../../common/Interfaces";
import {MillerFormulaCalculate} from "../../MillerFormula/Actions/MillerFormulaCalculate";
import {NaglerFormulaCalculate} from "../../NaglerFormula/Actions/NaglerFormulaCalculate";
import {IndexBorngardtCalculate} from "../../IndexBorngardt/Actions/IndexBorngardtCalculate";
import {DevinFormulaCalculate} from "../../DevinFormula/Actions/DevinFormulaCalculate";
import {HamviFormulaCalculate} from "../../HamviFormula/Actions/HamviFormulaCalculate";
import {MonnerotFormulaCalculate} from "../../MonnerotFormula/Actions/MonnerotFormulaCalculate";
import {EgorovaTableCalculate} from "../../EgorovaTable/Actions/EgorovaTableCalculate";
import {RobinsonFormulaCalculate} from "../../RobinsonFormula/Actions/RobinsonFormulaCalculate";
import {LorentzFormulaCalculate} from "../../LorentzFormula/Actions/LorentzFormulaCalculate";
import {IndexBrokaCalculate} from "../../IndexBroka/Actions/IndexBrokaCalculate";
import {MochammedFormulaCalculate} from "../../MochammedFormula/Actions/MochammedFormulaCalculate";
import {CuperFormulaCalculate} from "../../CuperFormula/Actions/CuperFormulaCalculate";
import {KreffFormulaCalculate} from "../../KreffFormula/Actions/KreffFormulaCalculate";
import {IndexSolovievaCalculate} from "../../IndexSolovieva/Actions/IndexSolovievaCalculate";
import {IndexBrokaBrukshaCalculate} from "../../IndexBrokaBruksha/Actions/IndexBrokaBrukshaCalculate";


export async function GeneralCalculate(
    height: number,
    isMan: boolean,
    age: number,
    wristLength: number,
    chestСircumference: number
  ) {
    let result: IGeneralResult[] = [];
  
    let egorovaTableCalculate = GetResult(
      (await EgorovaTableCalculate(height, isMan, age)).result?.result,
      "Таблица Егорова"
    );
    if (egorovaTableCalculate != null) result.push(egorovaTableCalculate);
  
    let millerFormulaCalculate = GetResult(
      (await MillerFormulaCalculate(height, isMan)).result?.result,
      "Формула Миллера"
    );
    if (millerFormulaCalculate != null) result.push(millerFormulaCalculate);
  
    let naglerFormulaCalculate = GetResult(
      (await NaglerFormulaCalculate(height, isMan)).result?.result,
      "Формула Наглера"
    );
    if (naglerFormulaCalculate != null) result.push(naglerFormulaCalculate);
  
    let mochammedFormulaCalculate = GetResult(
      (await MochammedFormulaCalculate(height)).result?.result,
      "Формула Моххамеда"
    );
    if (mochammedFormulaCalculate != null) result.push(mochammedFormulaCalculate);
  
    let robinsonFormulaCalculate = GetResult(
      (await RobinsonFormulaCalculate(height, isMan)).result?.result,
      "Формула Робинсона"
    );
    if (robinsonFormulaCalculate != null) result.push(robinsonFormulaCalculate);
  
    let hamviFormulaCalculate = GetResult(
      (await HamviFormulaCalculate(height, isMan)).result?.result,
      "Формула Хамви"
    );
    if (hamviFormulaCalculate != null) result.push(hamviFormulaCalculate);
  
    let cuperFormulaCalculate = GetResult(
      (await CuperFormulaCalculate(height, isMan)).result?.result,
      "Формула Купера"
    );
    if (cuperFormulaCalculate != null) result.push(cuperFormulaCalculate);
  
    let devinFormulaCalculate = GetResult(
      (await DevinFormulaCalculate(height, isMan)).result?.result,
      "Формула Девина"
    );
    if (devinFormulaCalculate != null) result.push(devinFormulaCalculate);
  
    let indexBrokaCalculate = GetResult(
      (await IndexBrokaCalculate(height, isMan)).result?.result,
      "Индекс Брока"
    );
    if (indexBrokaCalculate != null) result.push(indexBrokaCalculate);
  
    let indexBrokaBrukshaCalculate = GetResult(
      (await IndexBrokaBrukshaCalculate(height)).result?.result,
      "Индекс Брока-Бругша"
    );
    if (indexBrokaBrukshaCalculate != null)
      result.push(indexBrokaBrukshaCalculate);
  
    let lorentzFormulaCalculate = GetResult(
      (await LorentzFormulaCalculate(height, isMan)).result?.result,
      "Формула Лоренца"
    );
    if (lorentzFormulaCalculate != null) result.push(lorentzFormulaCalculate);
  
    if (wristLength !== 0) {
      let kreffFormulaCalculate = GetResult(
        (await KreffFormulaCalculate(height, age, wristLength)).result?.result,
        "Формула Креффа"
      );
      if (kreffFormulaCalculate != null) result.push(kreffFormulaCalculate);
  
      let monnerotFormulaCalculate = GetResult(
        (await MonnerotFormulaCalculate(height, wristLength)).result?.result,
        "Формула Моннерота-Думайна"
      );
      if (monnerotFormulaCalculate != null) result.push(monnerotFormulaCalculate);
  
      let indexSolovievaCalculate = GetResult(
        (await IndexSolovievaCalculate(isMan, wristLength)).result?.result,
        "Индекс Соловьева"
      );
      if (indexSolovievaCalculate != null) result.push(indexSolovievaCalculate);
    }
  
    if (chestСircumference !== 0) {
      let indexBorngardtCalculate = GetResult(
        (await IndexBorngardtCalculate(height, chestСircumference)).result
          ?.result,
        "Индекс Борнгардта"
      );
      if (indexBorngardtCalculate != null) result.push(indexBorngardtCalculate);
    }
    return result;
  }
  
  function GetResult(result: string | undefined, name: string) {
    if (result) {
      let res: IGeneralResult = {
        nameCalculator: name,
        result: result,
      };
  
      return res;
    }
    return null;
  }
  