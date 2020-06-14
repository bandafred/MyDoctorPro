import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import TitleCalculatorArray from "../../FormsComponets/TitleCalculator/TitleCalculatorArray";
import ResultMedCalcilate from "../../FormsComponets/ResultMedCalcilate/ResultMedCalcilate";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";
import { IResult, ISelectNameValue } from "../../../../common/Interfaces";
import ButtonResult from "../../FormsComponets/ButtonResult/ButtonResult";
import { GraceScaleResponse } from "../../../../apiClient/apiClient";
import SelectedNameValue from "../../FormsComponets/SelectedNameValue/SelectedNameValue";
import AgeSelect from "../../FormsComponets/AgeSelect/AgeSelect";
import InputInt from "../../FormsComponets/InputInt/InputInt";
import {GRACEResult} from "./GRACEAction";

const GRACE = () => {
  let def: IResult<GraceScaleResponse> = {
    error: undefined,
    result: undefined,
  };

  let killip: ISelectNameValue[] = [
    {
      name: "Отсутствие признаков застойной сердечной недостаточности (I)",
      value: 0,
    },
    {
      name:
        "Наличие хрипов в легких и/или повышенного давления в яремных венах (II)",
      value: 20,
    },
    { name: "Острый отек легких (III)", value: 39 },
    { name: "Кардиогенный шок (IV)", value: 59 },
  ];

  let ageDefault = 50;
  let heartRateDefault = 50;
  let systolicBloodPressureDefault = 120;
  let creatininDefault = 1;
  
  const [heartFailure, setHeartFailure] = useState(false);
  const [stSegmentDeviation, setStSegmentDeviation] = useState(false);
  const [highLevelOfCardiacEnzymes, setHighLevelOfCardiacEnzymes] = useState(
    false
  );

  const [age, setAge] = useState(ageDefault);
  const [heartRate, setHeartRate] = useState(heartRateDefault);
  const [systolicBloodPressure, setSystolicBloodPressure] = useState(systolicBloodPressureDefault);
  const [creatinin, setCreatinin] = useState(creatininDefault);

  const [kilip, setKillip] = useState(0);

  const [result, setResult] = useState(def);
  const [isLoad, setIsLoad] = useState(false);

  const calcing = async () => {
    setIsLoad(true);
    setResult(
      await GRACEResult(
        age,
        heartRate,
        systolicBloodPressure,
        creatinin,
        kilip,
        heartFailure,
        stSegmentDeviation,
        highLevelOfCardiacEnzymes
      )
    );
    setIsLoad(false);
  };

  return (
    <Row style={{ marginBottom: 100 }}>
      <Col span={24}>
        <TitleCalculatorArray
          name={"Шкала GRACE"}
          description={[
            "Шкала GRACE (Global Registry of Acute Coronary Events) позволяет оценить риск летальности и развития инфаркта миокарда на госпитальном этапе и в течение последующих 6 месяцев, а также определить оптимальный способ лечения конкретного больного. В момент поступления в стационар у пациента с ОКС при помощи шкалы GRACE оценивается риск развития ближайших (в процессе госпитального лечения) негативных сердечно-сосудистых исходов (смерть, инфаркт миокарда) при условии выбора консервативного лечения.",
            "При выборе лечебной стратегии должны быть приняты во внимание такие факторы, как качество жизни, продолжительность госпитального лечения и потенциальный риск, ассоциирующийся с инвазивной или консервативной стратегией. Решение о необходимости и экстренности проведения коронарографии у пациентов с ОКСбпST определяется после проведения стратификации риска по шкале GRACE(IB).",
          ]}
        />
      </Col>

      <Col xl={6}>
        <AgeSelect default={ageDefault} max={150} min={1} setAction={setAge} />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={50}
          max={150}
          min={1}
          setAction={setHeartRate}
          preName={"ЧСС"}
          postName={"уд/мин"}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={systolicBloodPressureDefault}
          max={300}
          min={1}
          setAction={setSystolicBloodPressure}
          preName={"Систолическое АД"}
          postName={"мм.рт.ст."}
        />
      </Col>

      <Col xl={6} style={{ marginTop: 10 }}>
        <InputInt
          default={creatininDefault}
          max={150}
          min={1}
          setAction={setCreatinin}
          preName={"Креатинин"}
          postName={"мкмоль/л"}
        />
      </Col>

      <Col xl={24} style={{ marginTop: 10 }}>
        <SelectedNameValue
          setAction={setKillip}
          name={"Класс сердечной недостаточности (по классификации Killip)"}
          width={550}
          values={killip}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect text={"Остановка сердца"} setAction={setHeartFailure} />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Отклонение сегмента ST"}
          setAction={setStSegmentDeviation}
        />
      </Col>

      <Col xl={24}>
        <SwitchSelect
          text={"Высокий уровень сердечных ферментов"}
          setAction={setHighLevelOfCardiacEnzymes}
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
export default GRACE;
