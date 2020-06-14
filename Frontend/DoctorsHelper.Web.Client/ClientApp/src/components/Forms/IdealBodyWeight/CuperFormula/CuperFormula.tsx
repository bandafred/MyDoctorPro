import * as React from "react";
import { Row, Col } from "antd";
import styles from "./CuperFormula.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { CuperFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {CuperFormulaCalculate} from "./Actions/CuperFormulaCalculate";

const CuperFormula = () => {
  let heightDefault = 121;
  let def: IResult<CuperFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await CuperFormulaCalculate(height, isMan));
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Купера"}
          description={
            'Формула автора популярной книги "Супердиета без жиров". Формула идеальной фигуры (Роберт К. Купер, Лесли Купер).'
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
          min={121}
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
export default CuperFormula;
