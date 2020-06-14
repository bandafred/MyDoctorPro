import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import { IResult } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import {
  PotassiumDeficiencyResponse,
} from "../../../../apiClient/apiClient";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {PotassiumDeficiencyResult} from "./PotassiumDeficiencyAction";

const PotassiumDeficiency = () => {
  let def: IResult<PotassiumDeficiencyResponse> = {
    error: undefined,
    result: undefined,
  };

  let bloodKaliumLevelDefault = 5;
  let bodyMassDefault = 70;

  const [bloodKaliumLevel, serBloodKaliumLevel] = useState(bloodKaliumLevelDefault);
  const [bodyMass, setBodyMass] = useState(bodyMassDefault);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(await PotassiumDeficiencyResult(bloodKaliumLevel, bodyMass));
    setIsLoad(false);
  };

  return (
    <Row style={{ marginBottom: 100 }}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Расчет дефицита калия в плазме крови"}
          description={[
            "Калий – важный минерал, который необходим для нормальной работы многих систем и органов человека. Количество калия в организме зависит от того, сколько его поступает с пищей, как он распределяется и выводится посредством почек, кишечника и потовых желез.",
            "Дефицит калия (ммоль/л) = (5 - калий плазмы пациента в ммоль/л) * 0.2 * массу тела пациента 1 ммоль калия = 39.1 мг калия. 1 грамм калия хлорида(KCL) = 13.4 ммоль калия.",
            "Дополнительные сведения: Общая суточная доза не должна превышать более 3 ммоль/кг/сут,а скорость инфузии - 20 ммоль/ч. Следует знать, что 7,5 % -ый раствор KCl является эквимолярным, то есть в 1 миллилтре такого раствора содержится 1 ммоль калия."
          ]}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={bloodKaliumLevelDefault}
          max={999}
          min={1}
          setAction={serBloodKaliumLevel}
          preName={"Калий сыворотки"}
          postName={"ммоль/л"}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={bodyMassDefault}
          max={999}
          min={1}
          setAction={setBodyMass}
          preName={"Вес пациента"}
          postName={"кг."}
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
export default PotassiumDeficiency;
