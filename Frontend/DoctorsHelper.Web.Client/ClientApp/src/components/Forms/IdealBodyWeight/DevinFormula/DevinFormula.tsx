import * as React from "react";
import { Row, Col } from "antd";
import styles from "./DevinFormula.module.css";
import { useState } from "react";
import GenderSelect from "../../FormsComponets/GenderSelect/GenderSelect";
import TitleCalculator from "../../FormsComponets/TitleCalculator/TitleCalculator";
import { DevinFormulaResponse } from "../../../../apiClient/apiClient";
import Result from "../../FormsComponets/Result/Result";
import HeightSelect from '../../FormsComponets/Height/HeightSelect';
import { IResult } from '../../../../common/Interfaces';
import ButtonResult from '../../FormsComponets/ButtonResult/ButtonResult';
import {DevinFormulaCalculate} from "./Actions/DevinFormulaCalculate";

const DevinFormula = () => {
  let heightDefault = 141;

  const [isMan, setIsMan] = useState(false);
  const [height, setHeight] = useState(heightDefault);

  let def: IResult<DevinFormulaResponse> = {
    error: undefined,
    result: undefined,
  };

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await DevinFormulaCalculate(height, isMan));
    setIsLoad(false);
  };
  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculator
          name={"Формула Девина"}
          description={
            'Формула Девина для расчета идеального веса была разработана в 1974 году доктором Девином для определения доз лекарственных средств. Но впоследствии стала широко распространена для расчета идеального веса. На основании этой формулы составлена большая часть калькуляторов идеального веса в интернете.'
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
          max={350}
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
export default DevinFormula;
