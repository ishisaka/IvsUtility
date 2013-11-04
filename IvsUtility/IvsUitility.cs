// ============================================================================
// opcdiary.IvsUtility - IvsUtility - IvsUitility.cs
// 
// Last update	:2013-11-04  Tadahiro Ishisaka
// Origin		:2013-11-04 
// ============================================================================
// 
// License:
// 
//    Copyright 2013 Tadahiro Ishisaka
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
// --------------------------------------------------------------------------
// 

namespace OpcDiary
{
    /// <summary>
    ///     IVSセレクタ文字列用のユーティリティクラス
    /// </summary>
    public static class IvsUtility
    {
        //日本の漢字の異字体セレクタはVariation Selector Supplementの範囲だけ使用される
        public const char VariationSelectorSupplementHi = '\uDB40';
        public const char VariationSelectorSupplementLoStart = '\uDD00';
        public const char VariationSelectorSupplementLoEnd = '\uDDEF';
        //それ以外だと以下が使われている可能性がある
        public const char VariationSelectorStart = '\uFE00';
        public const char VariationSelectorEnd = '\uFE0F';
        //モンゴル文字用
        public const char MongolianFreeVariationSelectorStart = '\u180B';
        public const char MongolianFreeVariationSelectorEnd = '\u180d';

        /// <summary>
        ///     文字列中の指定位置の文字がIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="s">文字列</param>
        /// <param name="index">s 内の評価する文字の位置。</param>
        /// <returns>s の index の位置にある文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        public static bool IsVariationSelector(this string s, int index)
        {
            return CheckSelector(s[index]);
        }

        /// <summary>
        ///     文字がIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="c">評価するUNICODE文字</param>
        /// <returns>文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        public static bool IsVariationSelector(this char c)
        {
            return CheckSelector(c);
        }

        /// <summary>
        ///     文字がIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="c">評価するUNICODE文字</param>
        /// <returns>文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        private static bool CheckSelector(char c)
        {
            if (c == VariationSelectorSupplementHi
                || (VariationSelectorSupplementLoStart <= c && c <= VariationSelectorSupplementLoEnd)
                || (VariationSelectorStart <= c && c <= VariationSelectorEnd)
                || (MongolianFreeVariationSelectorStart <= c && c <= MongolianFreeVariationSelectorEnd))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     文字がCJKでよく使われるIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="c">評価するUNICODE文字</param>
        /// <returns>文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        private static bool CheckVariationSelectorSupplement(char c)
        {
            if (c == VariationSelectorSupplementHi
                || (VariationSelectorSupplementLoStart <= c && c <= VariationSelectorSupplementLoEnd))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     文字がIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="c">評価するUNICODE文字</param>
        /// <returns>文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        private static bool CheckVariationSelector(char c)
        {
            if (VariationSelectorStart <= c && c <= VariationSelectorEnd)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///     文字がモンゴル語用のIVSのセレクタ文字列か判断する。
        /// </summary>
        /// <param name="c">評価するUNICODE文字</param>
        /// <returns>文字がセレクタ文字列の場合は true。それ以外の場合は false。</returns>
        private static bool CheckMongolianFreeVariationSelector(char c)
        {
            if (MongolianFreeVariationSelectorStart <= c && c <= MongolianFreeVariationSelectorEnd)
            {
                return true;
            }
            return false;
        }
    }
}