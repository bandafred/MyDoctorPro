import * as React from "react";
import { Row, Col } from "antd";
import styles from "./MonnerotFormula.module.css";
import { useState } from "react";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { MonnerotFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import WristLengthSelect from "../../FormsComponets/WristLengthSelect/WristLengthSelect";
import { IResult } from "../../../../common/Interfaces";
import {MonnerotFormulaCalculate} from "./Actions/MonnerotFormulaCalculate";

const MonnerotFormula = () => {
  let heightDefault = 141;
  let WristLength = 4;

  let def: IResult<MonnerotFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [wristLength, setWristLength] = useState(WristLength);
  const [height, setHeight] = useState(heightDefault);
  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await MonnerotFormulaCalculate(height, wristLength));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Моннерота-Думайна"}
          description={
            "Формула Моннерота-Думайна учитывает тип телосложения, костную и мышечную массу человека."
          }
        />
      </Col>

      <Col xl={6}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={100}
          max={350}
        />
      </Col>

      <Col xl={11}>
        <WristLengthSelect
          setWristLength={setWristLength}
          default={WristLength}
          min={4}
          max={50}
        />
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
export default MonnerotFormula;
