import * as React from "react";
import { Row, Col } from "antd";
import styles from "./LorentzFormula.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { LorentzFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {LorentzFormulaCalculate} from "./Actions/LorentzFormulaCalculate";

const LorentzFormula = () => {
  let heightDefault = 141;
  let def: IResult<LorentzFormulaResponse> = {
    error: undefined,
    result: undefined,
  };
  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await LorentzFormulaCalculate(height, isMan));
    setIsLoad(false);
  };
  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Лоренца"}
          description={
            "Формула Лоренца для расчета идеального веса разработана в 1929 году и имеет две версии: для мужчин и женщин. Подходит людям старше 18 лет и ростом от 140 до 220 см. Это самая простая формула, чтобы рассчитать свой вес. В очевидной простоте метода кроется и положительная, и отрицательная сторона. Формула Лоренца не дифференцирует людей по типам (астенический, нормостенический, гиперстенический), не учитывает возраст и наличие физических нагрузок. Результат может считаться довольно усредненным."
          }
        />
      </Col>

      <Col xl={3} className={styles.genderSelect}>

        <GenderSelect isMan={isMan} setIsMan={setIsMan} />
      </Col>

      <Col xl={11}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={141}
          max={220}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <Result result={result.result?.result} error={result.error}/>
      </Col>
    </Row>
  );
};
export default LorentzFormula;
