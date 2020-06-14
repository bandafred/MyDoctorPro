import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {
  IndexSmokeResponse,
} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {IndexSmokeResult} from "./IndexSmokeAction";

const IndexSmoke = () => {
  let def: IResult<IndexSmokeResponse> = {
    error: undefined,
    result: undefined,
  };

  let ageSmokeDefault = 1;
  let countSigarDefault = 1;
  
  const [ageSmoke, serAgeSmoke] = useState(ageSmokeDefault);
  const [countSigar, setCountSigar] = useState(countSigarDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await IndexSmokeResult(ageSmoke, countSigar));
    setIsLoad(false);
  };

  return (
    <Row style={{ marginBottom: 100 }}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Индекс курения"}
          description={[
            "Индекс курения основной показатель используемый для определения риска развития хронической обструктивной болезни легких. Рассчитывается как произведение количества выкуриваемых сигарет в день и стажа курения в годах поделенное на 20.",
            "Если индекс курения больше 10, то это является достоверным фактором риска развития хронической обструктивной болезни легких.",
          ]}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={ageSmokeDefault}
          max={150}
          min={1}
          setAction={serAgeSmoke}
          preName={"Стаж курения"}
          postName={"лет"}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={countSigarDefault}
          max={999}
          min={1}
          setAction={setCountSigar}
          preName={"Количество сигарет в день"}
          postName={"шт."}
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
export default IndexSmoke;
