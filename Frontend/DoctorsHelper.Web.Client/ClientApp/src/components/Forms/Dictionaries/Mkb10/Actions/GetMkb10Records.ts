import {Mkb10Response, Mkb10Client} from "../../../../../apiClient/apiClient";
import {IResult, IErrors} from '../../../../../common/Interfaces';
import {getAuthClient} from "../../../../../apiClient/getAuthClient";

export async function GetMkb10Records(searchText: string | null | undefined, skipCount: number | undefined, takeCount: number | undefined) {
    let res: IResult<Mkb10Response> = {
        result: undefined,
        error: undefined
    };

    try {
        let client = new Mkb10Client(getAuthClient());
        res.result = await client.getRecords(searchText, skipCount, takeCount);

        return res;

    } catch (error) {
        res.error = <IErrors>JSON.parse(error.response);
        return res;
    }
}