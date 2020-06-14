import * as React from "react";
import { Row, Col } from "antd";
import styles from "./MochammedFormula.module.css";
import { useState } from "react";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { MochammedFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from "../../FormsComponets/Height/HeightSelect";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { IResult } from "../../../../common/Interfaces";
import {MochammedFormulaCalculate} from "./Actions/MochammedFormulaCalculate";

const MochammedFormula = () => {
  let heightDefault = 120;

  let def: IResult<MochammedFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [height, setHeight] = useState(heightDefault);
  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await MochammedFormulaCalculate(height));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Моххамеда"}
          description={
            "Одна из самых новых формул, появилась в 2010 году. Не имеет таких недостатков некоторых старых формул как неправильный результат при невысоком или очень высокой росте."
          }
        />
      </Col>

      <Col xl={24}>
        <HeightSelect
          setAction={setHeight}
          default={heightDefault}
          min={120}
          max={300}
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
export default MochammedFormula;
