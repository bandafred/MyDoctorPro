import {IResult, IErrors} from '../../../../../common/Interfaces';
import {EgorovaTableResponse, EgorovaTableClient} from '../../../../../apiClient/apiClient';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function EgorovaTableCalculate(
    height: number,
    isMan: boolean,
    age: number
) {
    let res: IResult<EgorovaTableResponse> = {
        result: undefined,
        error: undefined,
    };

    try {
        let client = new EgorovaTableClient(getAuthClient());
        res.result = await client.calculate(height, isMan, age);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}