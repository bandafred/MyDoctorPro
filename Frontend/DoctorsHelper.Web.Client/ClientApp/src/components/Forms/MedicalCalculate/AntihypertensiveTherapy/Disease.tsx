import * as React from "react";
import { Row, Col } from "antd";
import { useState } from "react";
import SwitchSelect from "../../FormsComponets/SwitchSelect/SwitchSelect";

export const Disease = (props: { setDiseases: Function }) => {
  const [coronaryHeartDisease, setCoronaryHeartDisease] = useState(false);
  const [leftVentricularHypertrophy, setLeftVentricularHypertrophy] = useState(false);
  const [atrialFibrillation, setAtrialFibrillation] = useState(false);
  const [diabetes, setDiabetes] = useState(false);
  const [myocardialInfarction, setMyocardialInfarction] = useState(false);
  const [kidneyDamage, setKidneyDamage] = useState(false);
  const [chronicHeartFailure, setChronicHeartFailure] = useState(false);
  const [proteinInTheUrine, setProteinInTheUrine] = useState(false);
  const [atherosclerosisOfTheCarotidAndCoronaryArteries, setAtherosclerosisOfTheCarotidAndCoronaryArteries] = useState(false);
  const [glaucoma, setGlaucoma] = useState(false);
  const [pregnancy, setPregnancy] = useState(false);
  const [tachyarrhythmia, setTachyarrhythmia] = useState(false);
  const [chronicObstructivePulmonaryDisease, setChronicObstructivePulmonaryDisease] = useState(false);
  const [bronchialAsthma, setBronchialAsthma] = useState(false);
  const [chronicRenalFailure, setChronicRenalFailure] = useState(false);
  const [metabolicSyndrome, setMetabolicSyndrome] = useState(false);
  const [bilateralRenalArteryStenosis, setBilateralRenalArteryStenosis] = useState(false);
  const [coughFromTakingAngiotensinConvertingEnzymeInhibitors, setCoughFromTakingAngiotensinConvertingEnzymeInhibitors] = useState(false);
  const [gout, setGout] = useState(false);
  const [atrioventricularBlockOfTheSecondOrThirdDegree, setAtrioventricularBlockOfTheSecondOrThirdDegree] = useState(false);
  const [hyperkalemia, setHyperkalemia] = useState(false);
  const [angioneuroticEdema, setAngioneuroticEdema] = useState(false);

   React.useEffect(() => {
     let res: number[] = [];
     if (coronaryHeartDisease) res.push(0);
     if (leftVentricularHypertrophy) res.push(1);
     if (atrialFibrillation) res.push(2);
     if (diabetes) res.push(3);
     if (myocardialInfarction) res.push(4);
     if (kidneyDamage) res.push(5);
     if (chronicHeartFailure) res.push(6);
     if (proteinInTheUrine) res.push(7);
     if (atherosclerosisOfTheCarotidAndCoronaryArteries) res.push(8);
     if (glaucoma) res.push(9);
     if (pregnancy) res.push(10);
     if (tachyarrhythmia) res.push(11);
     if (chronicObstructivePulmonaryDisease) res.push(12);
     if (bronchialAsthma) res.push(13);
     if (chronicRenalFailure) res.push(14);
     if (metabolicSyndrome) res.push(15);
     if (bilateralRenalArteryStenosis) res.push(16);
     if (coughFromTakingAngiotensinConvertingEnzymeInhibitors) res.push(17);
     if (gout) res.push(18);
     if (atrioventricularBlockOfTheSecondOrThirdDegree) res.push(19);
     if (hyperkalemia) res.push(20);
     if (angioneuroticEdema) res.push(21);

     props.setDiseases(res);
   }, [coronaryHeartDisease, leftVentricularHypertrophy, atrialFibrillation, diabetes, myocardialInfarction, kidneyDamage, chronicHeartFailure, proteinInTheUrine,
    atherosclerosisOfTheCarotidAndCoronaryArteries, glaucoma, pregnancy, tachyarrhythmia, chronicObstructivePulmonaryDisease,
    bronchialAsthma, chronicRenalFailure, metabolicSyndrome, bilateralRenalArteryStenosis, coughFromTakingAngiotensinConvertingEnzymeInhibitors,
    gout, atrioventricularBlockOfTheSecondOrThirdDegree, hyperkalemia, angioneuroticEdema]);

  return (
    <Row>
      <Col span={8}>
        <SwitchSelect
          setAction={setCoronaryHeartDisease}
          text={"Ишемическая болезнь сердца"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setLeftVentricularHypertrophy}
          text={"Гипертрофия левого желудочка"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setAtrialFibrillation}
          text={"Мерцательная аритмия"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect setAction={setDiabetes} text={"Сахарный диабет"} />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setMyocardialInfarction}
          text={"Перенесенный инфаркт миокарда"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setKidneyDamage}
          text={"Поражение почек"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setChronicHeartFailure}
          text={"Хроническая сердечная недостаточность"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setProteinInTheUrine}
          text={"Белок в моче"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setAtherosclerosisOfTheCarotidAndCoronaryArteries}
          text={"Атеросклероз сонных и коронарных артерий"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setGlaucoma}
          text={"Глаукома"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setPregnancy}
          text={"Беременность"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setTachyarrhythmia}
          text={"Тахиаритмия"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setChronicObstructivePulmonaryDisease}
          text={"Хроническая обструктивная болезнь легких"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setBronchialAsthma}
          text={"Бронхиальная астма"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setChronicRenalFailure}
          text={"Хроническая почечная недостаточность"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setMetabolicSyndrome}
          text={"Метаболический синдром"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setBilateralRenalArteryStenosis}
          text={"Двусторонний стеноз почечных артерий"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setCoughFromTakingAngiotensinConvertingEnzymeInhibitors}
          text={"Кашель от приема иАПФ"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setGout}
          text={"Подагра"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setAtrioventricularBlockOfTheSecondOrThirdDegree}
          text={"АВ-блокада 2-3 степени"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setHyperkalemia}
          text={"Гиперкалиемия"}
        />
      </Col>
      <Col span={8}>
        <SwitchSelect
          setAction={setAngioneuroticEdema}
          text={"Ангионевротический отек (отек Квинке)"}
        />
      </Col>
    </Row>
  );
};
