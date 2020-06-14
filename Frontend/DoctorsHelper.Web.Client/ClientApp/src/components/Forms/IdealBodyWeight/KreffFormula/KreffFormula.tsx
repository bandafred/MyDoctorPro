import * as React from "react";
import { Row, Col } from "antd";
import styles from "./KreffFormula.module.css";
import { useState } from "react";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { KreffFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import WristLengthSelect from "../../FormsComponets/WristLengthSelect/WristLengthSelect";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import { IResult } from "../../../../common/Interfaces";
import {KreffFormulaCalculate} from "./Actions/KreffFormulaCalculate";


const KreffFormula = () => {
  let heightDefault = 111;
  let wristLengtDefault = 4;
  let ageDefault = 19;

  let def: IResult<KreffFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [height, setHeight] = useState(heightDefault);
  const [wristLengt, setWristLengt] = useState(wristLengtDefault);
  const [age, setAge] = useState(ageDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await KreffFormulaCalculate(height, age, wristLengt));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Креффа"}
          description={
            "Формула Креффа улучшает индекс Брока с учетом комплекции. В данной формуле учитывается не только телосложение, но и возраст."
          }
        />
      </Col>

      <Col xl={6}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={111}
          max={220}
        />
      </Col>

      <Col xl={10}>
        <WristLengthSelect
          setWristLength={setWristLengt}
          default={wristLengtDefault}
          min={4}
          max={50}
        />
      </Col>

      <Col xl={8}>
        <AgeSelect setAction={setAge} default={ageDefault} min={19} max={300} />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <Result result={result.result?.result} error={result.error} />
      </Col>
    </Row>
  );
};
export default KreffFormula;
