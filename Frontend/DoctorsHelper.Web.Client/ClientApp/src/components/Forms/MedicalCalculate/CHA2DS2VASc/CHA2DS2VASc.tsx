import * as React from "react";
import { Row, Col } from "antd";
import styles from "./CHA2DS2VASc.module.css";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { CHA2DS2VAScResponse } from "../../../../apiClient/apiClient";
import AgeMultiSelect from "../../FormsComponets/AgeMultiSelect/AgeMultiSelect";
import SexSelect from "../../FormsComponets/SexSelect/SexSelect";
import {CHA2DS2VASResult} from "./CHA2DS2VAScAction";

const CHA2DS2VASc = () => {
  let def: IResult<CHA2DS2VAScResponse> = {
    error: undefined,
    result: undefined,
  };

  const [isInsult, setIsInsult] = useState(false);
  const [isOld75, setIsOld75] = useState(false);
  const [isOld65, setIsOld65] = useState(false);
  const [isArterialHypertension, setIsArterialHypertension] = useState(false);
  const [isDiabetes, setIsDiabetes] = useState(false);
  const [isHeartFailure, setIsHeartFailure] = useState(false);
  const [isMyocardialInfarction, setIsMyocardialInfarction] = useState(false);
  const [isWomen, setIsWomen] = useState(false);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(
      await CHA2DS2VASResult(
        isInsult,
        isOld75,
        isOld65,
        isArterialHypertension,
        isDiabetes,
        isHeartFailure,
        isMyocardialInfarction,
        !isWomen
      )
    );
    setIsLoad(false);
  };

  return (
    <Row className={styles.wrap}>
      <Col span={24}>
        <TitleCalculatorArray
          name={
            "Шкала CHA2DS2VASc для оценки риска тромбоэмболических осложнений у больных с фибрилляцией/трепетанием предсердий"
          }
          description={[
            "Шкала CHA2DS2VASc является простым и доступным методом для оценки риска развития инсульта и тромбоэмболических осложнений у пациентов с трепетанием и фибрилляцией предсердий. Шкала является дальнейшим развитием шкалы CHADS2, в которую добавлены дополнительные факторы риска развития инсульта.",
          ]}
        />
      </Col>

      <Col xl={4}>
        <AgeMultiSelect
          setActionOld65={setIsOld65}
          setActionOld75={setIsOld75}
        />
      </Col>

      <Col xl={12}>
        <SexSelect setAction={setIsWomen} />
      </Col>

    
      <Col xl={24}>
        <SwitchSelect
          text={"Артериальная гипертензия"}
          setAction={setIsArterialHypertension}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={
            "Инсульт, транзиторная ишемическая атака или артериальная тромбоэмболия в анамнезе"
          }
          setAction={setIsInsult}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect text={"Сахарный диабет"} setAction={setIsDiabetes} />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={
            "Застойная сердечная недостаточность/дисфункция ЛЖ (в частности, ФВ ≤40 %)"
          }
          setAction={setIsHeartFailure}
        />
      </Col>
      <Col xl={24}>
        <SwitchSelect
          text={
            "Сосудистое заболевание (инфаркт миокарда в анамнезе, периферический атеросклероз,атеросклеротические бляшки в аорте)"
          }
          setAction={setIsMyocardialInfarction}
        />
      </Col>

      <Col xl={24}>
        <ButtonResult isLoad={isLoad} calcing={calcing} />
      </Col>

      <Col xl={24}>
        <ResultMedCalcilate
          result={result.result?.result}
          error={result.error}
        />
      </Col>
    </Row>
  );
};
export default CHA2DS2VASc;
